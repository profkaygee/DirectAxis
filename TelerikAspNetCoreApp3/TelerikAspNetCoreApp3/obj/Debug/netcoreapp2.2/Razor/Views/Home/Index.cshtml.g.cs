#pragma checksum "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11e71032af83a42c9ac161f0368ae0bd5db4b6e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\_ViewImports.cshtml"
using TelerikAspNetCoreApp3;

#line default
#line hidden
#line 2 "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11e71032af83a42c9ac161f0368ae0bd5db4b6e7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4ce6ae9480189926ecd7d32ab0cb351cd7d3a8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 13, true);
            WriteLiteral("\r\n<div>\r\n    ");
            EndContext();
            BeginContext(60, 1844, false);
#line 6 "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\Home\Index.cshtml"
Write(Html.Kendo().PanelBar()
                                            .Name("IntroPanelBar")
                                            .Items(items =>
                                            {
                                                items.Add()
                                                    .Text("ASP.NET Core")
                                                    .Selected(true)
                                                    .Expanded(true)
                                                    .Content(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(603, 477, true);
    WriteLiteral(@"
                                                        <p style=""padding:1em 2em"">
                                                            Learn how to build ASP.NET apps that can run anywhere.
                                                            <a target=""_blank"" href=""http://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409"">Learn More</a>
                                                        </p>
                                                    ");
    EndContext();
    PopWriter();
}
));
                                                        items.Add()
            .Text("Visual Studio")
            .Content(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(1224, 301, true);
    WriteLiteral(@"
                <p style=""padding:1em 2em"">
                    There are powerful new features in Visual Studio for building modern web apps.
                    <a target=""_blank"" href=""http://go.microsoft.com/fwlink/?LinkID=525030&clcid=0x409"">Learn More</a>
                </p>
            ");
    EndContext();
    PopWriter();
}
));
                                            items.Add()
.Text("Package Management")
.Content(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(1638, 249, true);
    WriteLiteral("\r\n    <p style=\"padding:1em 2em\">\r\n        Bring in libraries from NuGet, Bower, and npm, and automate tasks using Grunt or Gulp.\r\n        <a target=\"_blank\" href=\"http://go.microsoft.com/fwlink/?LinkID=525029&clcid=0x409\">Learn More</a>\r\n    </p>\r\n");
    EndContext();
    PopWriter();
}
));
                                        })
    );

#line default
#line hidden
            EndContext();
            BeginContext(1947, 8, true);
            WriteLiteral("\r\n</div>");
            EndContext();
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