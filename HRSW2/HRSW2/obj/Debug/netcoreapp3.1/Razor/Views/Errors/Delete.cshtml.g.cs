#pragma checksum "E:\PROJECT\CSHARP\bt2\HRSW2\HRSW2\Views\Errors\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87b78a3546daba5a5b4bef23d5188ad6a8c09f09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Errors_Delete), @"mvc.1.0.view", @"/Views/Errors/Delete.cshtml")]
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
#line 1 "E:\PROJECT\CSHARP\bt2\HRSW2\HRSW2\Views\_ViewImports.cshtml"
using HRSW2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PROJECT\CSHARP\bt2\HRSW2\HRSW2\Views\_ViewImports.cshtml"
using HRSW2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87b78a3546daba5a5b4bef23d5188ad6a8c09f09", @"/Views/Errors/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"827355ef4886904ae5b7224c58f34b8e53dfbbf4", @"/Views/_ViewImports.cshtml")]
    public class Views_Errors_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HRSW2.Models.Errors>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h3>");
#nullable restore
#line 2 "E:\PROJECT\CSHARP\bt2\HRSW2\HRSW2\Views\Errors\Delete.cshtml"
Write(Html.DisplayFor(x => x.MessageError));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HRSW2.Models.Errors> Html { get; private set; }
    }
}
#pragma warning restore 1591