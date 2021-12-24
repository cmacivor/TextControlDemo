#pragma checksum "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\DocumentEditor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21751e0d8508511420db498dafe1f2543e117e09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DocumentEditor), @"mvc.1.0.view", @"/Views/Home/DocumentEditor.cshtml")]
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
#line 1 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\DocumentEditor.cshtml"
using TXTextControl.Web.MVC;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21751e0d8508511420db498dafe1f2543e117e09", @"/Views/Home/DocumentEditor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"958cf3edb162510f77a1a3ebe5eb16e3115265b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DocumentEditor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\CraigMacIvor\source\repos\TextControlDemo\TextControlDemo\Views\Home\DocumentEditor.cshtml"
Write(Html.TXTextControl().TextControl().Render());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<input type=\"button\" value=\"Create PDF\" onclick=\"createPDF()\" />\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

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

	        function createPDF() {
	            // save the contents of the editor
	            TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat, function (e) {

	                // call the Web API ""CreatePDF""
	                $.ajax({
	                    type: ""POST"",
	                    url: ""/Home/CreatePDF?id=123"",
	                    contentType: 'application/json',
	                    data: JSON.stringify({
	                        document: e.data
	                    }),

	          ");
                WriteLiteral(@"          success: successFunc,
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

	                function errorFunc(xhr, ajaxOptions, thrownError) {
	                    alert(thrownError);
	                }
	            });
	        }
    </sc");
                WriteLiteral("ript>\r\n");
            }
            );
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
