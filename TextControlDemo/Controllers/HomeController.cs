using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextControlDemo.Models;
using Microsoft.AspNetCore.Hosting;


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
    }
}
