#pragma checksum "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02c4854190d4dd9913e0dd3683f0624daace28c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AccessDenied), @"mvc.1.0.view", @"/Views/Account/AccessDenied.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/AccessDenied.cshtml", typeof(AspNetCore.Views_Account_AccessDenied))]
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
#line 1 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/_ViewImports.cshtml"
using UniversityApp;

#line default
#line hidden
#line 3 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/_ViewImports.cshtml"
using UniversityApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02c4854190d4dd9913e0dd3683f0624daace28c4", @"/Views/Account/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2da697c3d452f4f1f04b3d3ce2a1109795777589", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\n\n");
            EndContext();
#line 3 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
  
    ViewData["Title"] = "Access denied";

#line default
#line hidden
            BeginContext(48, 85, true);
            WriteLiteral("\n<h1>You can\'t access this page 404 Error</h1>\n\n<header>\n    <h2 class=\"text-danger\">");
            EndContext();
            BeginContext(134, 17, false);
#line 10 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(151, 58, true);
            WriteLiteral("</h2>\n    <p>You do not have access to this resource.</p>\n");
            EndContext();
#line 12 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
     if (User.IsInRole("Admin"))
    {

#line default
#line hidden
            BeginContext(248, 59, true);
            WriteLiteral("        <h2>You can not access: <span class=\"text-success\">");
            EndContext();
            BeginContext(308, 21, false);
#line 14 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
                                                      Write(ViewData["ReturnUrl"]);

#line default
#line hidden
            EndContext();
            BeginContext(329, 72, true);
            WriteLiteral("</span> because you are an <span class=\"text-danger\">Admin!</span></h2>\n");
            EndContext();
#line 15 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
    }

#line default
#line hidden
            BeginContext(407, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 16 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
     if (User.IsInRole("Teacher"))
    {

#line default
#line hidden
            BeginContext(448, 59, true);
            WriteLiteral("        <h2>You can not access: <span class=\"text-success\">");
            EndContext();
            BeginContext(508, 21, false);
#line 18 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
                                                      Write(ViewData["ReturnUrl"]);

#line default
#line hidden
            EndContext();
            BeginContext(529, 73, true);
            WriteLiteral("</span> because you are a <span class=\"text-danger\">Teacher!</span></h2>\n");
            EndContext();
#line 19 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
    }

#line default
#line hidden
            BeginContext(608, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 20 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
     if (User.IsInRole("Student"))
    {

#line default
#line hidden
            BeginContext(649, 59, true);
            WriteLiteral("        <h2>You can not access: <span class=\"text-success\">");
            EndContext();
            BeginContext(709, 21, false);
#line 22 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
                                                      Write(ViewData["ReturnUrl"]);

#line default
#line hidden
            EndContext();
            BeginContext(730, 73, true);
            WriteLiteral("</span> because you are a <span class=\"text-danger\">Student!</span></h2>\n");
            EndContext();
#line 23 "/Users/davidgonzalez/Documents/personal_code/UniversityApp/Views/Account/AccessDenied.cshtml"
    }

#line default
#line hidden
            BeginContext(809, 9, true);
            WriteLiteral("</header>");
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