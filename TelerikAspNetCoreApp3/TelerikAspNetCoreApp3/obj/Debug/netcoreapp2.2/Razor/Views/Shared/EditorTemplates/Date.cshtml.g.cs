#pragma checksum "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\Shared\EditorTemplates\Date.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19bc94313b5e2f73ffd14555b58b1b1b8ab83ee9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_Date), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/Date.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/EditorTemplates/Date.cshtml", typeof(AspNetCore.Views_Shared_EditorTemplates_Date))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19bc94313b5e2f73ffd14555b58b1b1b8ab83ee9", @"/Views/Shared/EditorTemplates/Date.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4ce6ae9480189926ecd7d32ab0cb351cd7d3a8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_Date : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(22, 34, false);
#line 3 "C:\Users\KagisoM\source\repos\TelerikAspNetCoreApp3\TelerikAspNetCoreApp3\Views\Shared\EditorTemplates\Date.cshtml"
Write(Html.Kendo().DatePickerFor(m => m));

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime?> Html { get; private set; }
    }
}
#pragma warning restore 1591
