using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextControlDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Npgsql;
using Dapper;

namespace TextControlDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostingEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocumentEditor()
        {
            var webRoot = _env.WebRootPath;

            //var file = System.IO.Path.Combine(webRoot, "test.txt");
            var documentDirectory = System.IO.Path.Combine(webRoot, "textcontrol");
            var sampleDb = System.IO.Path.Combine(webRoot, "textcontrol", "sample_db.xml");
            var invoice = System.IO.Path.Combine(webRoot, "textcontrol", "invoice.docx");


            ViewData["sampleDb"] = sampleDb;
            ViewData["invoice"] = invoice;
            ViewData["documentDirectory"] = documentDirectory;



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CreatePDF([FromBody] TransferDocument document)
        {

            // create a ServerTextControl
            using TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl();

            tx.Create();
            tx.Load(Convert.FromBase64String(document.Document),
              TXTextControl.BinaryStreamType.InternalUnicodeFormat);

            byte[] bPDF;

            tx.Save(out bPDF, TXTextControl.BinaryStreamType.AdobePDF);

            return Ok(bPDF);
        }

        [HttpPost]
        public IActionResult SaveTemplate([FromBody] DocumentViewModel model)
        {
            string name = model.DocumentName;
            byte[] document = Convert.FromBase64String(model.BinaryDocument);

            var webRoot = _env.WebRootPath;
            var documentDirectory = System.IO.Path.Combine(webRoot, "textcontrol", model.DocumentName);

            var guid = Guid.NewGuid();

            using (var connection = new NpgsqlConnection("User ID=postgres;Password=Emmett2810$;Host=localhost;Port=5432;Database=TextControlDemo;"))
            {

                string sql = @"INSERT INTO public.""Document"" (""Name"", ""UniqueId"") VALUES(@Name, @UniqueId)";
                connection.Execute(sql, new { Name = model.DocumentName, UniqueId = guid });
            }

            using (TXTextControl.ServerTextControl tx =
                new TXTextControl.ServerTextControl())
            {
                tx.Create();
                tx.Load(document, TXTextControl.BinaryStreamType.InternalUnicodeFormat);

                tx.Save(documentDirectory,
                    TXTextControl.StreamType.WordprocessingML);
            }

            return Json("success");
        }

        // loads a document into the ServerTextControl and returns the
        // document as a base64 encoded string
        [HttpPost]
        public string LoadTemplate([FromBody] LoadDocumentViewModel model)
        {
            byte[] data;

            var webRoot = _env.WebRootPath;
            var documentDirectory = System.IO.Path.Combine(webRoot, "textcontrol", model.DocumentName);

            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
            {
                tx.Create();
                tx.Load(documentDirectory, TXTextControl.StreamType.WordprocessingML);

                tx.Save(out data, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            }

            return Convert.ToBase64String(data);
        }
    }
}
