#pragma checksum "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ede4f48216dce968e787d20ba8485ac40d3cdb9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\_ViewImports.cshtml"
using TextControlDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\_ViewImports.cshtml"
using TextControlDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\Index.cshtml"
using TXTextControl.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\Index.cshtml"
using TXTextControl.Web.MVC;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ede4f48216dce968e787d20ba8485ac40d3cdb9f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"958cf3edb162510f77a1a3ebe5eb16e3115265b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<input type=""button"" value=""Create PDF"" onclick=""createPDF()"" />

<!-- Trigger/Open The Modal -->
<button id=""myBtn"" >Open Modal</button>

<!-- The Modal -->
<div id=""myModal"" class=""modal"">
    <!-- Modal content -->
    <div class=""modal-content"">
        <div class=""modal-header"">
            <span class=""close"">&times;</span>
            <h2>Modal Header</h2>
        </div>
        <div id=""editor""></div>
        <div class=""modal-footer"">
            <h3>Modal Footer</h3>
            <input type=""text"" id=""txtFileName"" placeholder=""File name"" />
            <input onclick=""loadFile()"" id=""btnLoad"" type=""button"" value=""Load"" />
            <input onclick=""saveFile()"" id=""btnSave"" type=""button"" value=""Save"" />
        </div>
    </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

           function loadEditor() {
	        // check, if editor exists and
	        // closes the WebSocket connection gracefully
	        // and removes the whole editor from the DOM.
	        if (typeof TXTextControl !== 'undefined')
	            TXTextControl.removeFromDom();

	        // load the partial view
	        $('#editor').load('");
#nullable restore
#line 41 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\Index.cshtml"
                          Write(Url.Action("EditorPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
	    }

        // converts base64 string back to a blob
        function base64ToBlob(base64) {
            var binary = atob(base64.replace(/\s/g, ''));
            var len = binary.length;
            var buffer = new ArrayBuffer(len);
            var view = new Uint8Array(buffer);

            for (var i = 0; i < len; i++) {
                view[i] = binary.charCodeAt(i);
            }

            return view;
        }

        function saveFile() {
            var fileName = document.getElementById(""txtFileName"").value;

            SaveToController(fileName);
        }

        function loadFile() {
            var fileName = document.getElementById(""txtFileName"").value;
            LoadFromController(fileName);
        }

        function SaveToController(DocumentName) {
            TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat,
                function (e) {
                    console.log(DocumentName)
                    console.log(e");
                WriteLiteral(@".data)
                    var serviceURL = ""/Home/SaveTemplate"";

                    $.ajax({
                        type: ""POST"",
                        url: serviceURL,
                        contentType: 'application/json',
                        data: JSON.stringify({
                            DocumentName: DocumentName,
                            BinaryDocument: e.data
                        }),
                        success: successFunc,
                        error: errorFunc
                    });

                    function successFunc(data, status) {
                        alert(""Document has been saved successfully."");
                    }

                    function errorFunc() {
                        alert('Error');
                    }
                });
        }

        // load the document from the controller and load
        // it into the TXTextControl.Web
        function LoadFromController(DocumentName) {
            var serviceURL = ""/");
                WriteLiteral(@"Home/LoadTemplate"";
            $.ajax({
                type: ""POST"",
                url: serviceURL,
                contentType: 'application/json',
                data: JSON.stringify({
                    DocumentName: DocumentName
                }),
                success: successFunc,
                error: errorFunc
            });
            function successFunc(data, status) {
                TXTextControl.loadDocument(TXTextControl.streamType.InternalUnicodeFormat, data);
            }
            function errorFunc() {
                alert('Error');
            }

        }

        function createPDF() {
            // save the contents of the editor
            TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat, function (e) {

                // call the Web API ""CreatePDF""
                $.ajax({
                    type: ""POST"",
                    url: ""/Home/CreatePDF?id=123"",
                    contentType: 'application/json',
   ");
                WriteLiteral(@"                 data: JSON.stringify({
                        document: e.data
                    }),

                    success: successFunc,
                    error: errorFunc
                });

                function successFunc(data, status) {
                    // create a file blob
                    var file = new Blob([base64ToBlob(data)], { type: ""application/pdf"" });

                    // create a temporary link element
                    var a = document.createElement(""a"");
                    a.href = URL.createObjectURL(file);
                    a.download = ""results.pdf"";

                    // attach to body and click
                    document.body.appendChild(a);
                    a.click();

                    // remove the element
                    setTimeout(function () {
                        document.body.removeChild(a);
                    }, 0);

                }

                function errorFunc(xhr, ajaxOptions, thrownError) {");
                WriteLiteral(@"
                    alert(thrownError);
                }
            });
        }

        // Get the modal
        var modal = document.getElementById(""myModal"");

        // Get the button that opens the modal
        var btn = document.getElementById(""myBtn"");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName(""close"")[0];

        // When the user clicks on the button, open the modal
        btn.onclick = function () {
            modal.style.display = ""block"";
            loadEditor();
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = ""none"";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = ""none"";
            }
        }

    </script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
