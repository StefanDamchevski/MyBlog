#pragma checksum "C:\Users\Stefan\Desktop\Academy\MVC\MyBlog\MyBlog\Views\Blog\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c478cf778fc623b8acb365c314de46e3198b812"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Details), @"mvc.1.0.view", @"/Views/Blog/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Blog/Details.cshtml", typeof(AspNetCore.Views_Blog_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c478cf778fc623b8acb365c314de46e3198b812", @"/Views/Blog/Details.cshtml")]
    public class Views_Blog_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyBlog.Models.Blog>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Stefan\Desktop\Academy\MVC\MyBlog\MyBlog\Views\Blog\Details.cshtml"
  
    Layout = "_Layout";
    ViewBag.PageName = "Blog Details";

#line default
#line hidden
            BeginContext(101, 57, true);
            WriteLiteral("\r\n<div class=\"movie-details\">\r\n    <img class=\"movie-img\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 158, "\"", 179, 1);
#line 9 "C:\Users\Stefan\Desktop\Academy\MVC\MyBlog\MyBlog\Views\Blog\Details.cshtml"
WriteAttributeValue("", 164, Model.ImageUrl, 164, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(180, 34, true);
            WriteLiteral(" />\r\n    <div class=\"movie-title\">");
            EndContext();
            BeginContext(215, 11, false);
#line 10 "C:\Users\Stefan\Desktop\Academy\MVC\MyBlog\MyBlog\Views\Blog\Details.cshtml"
                        Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(226, 49, true);
            WriteLiteral("</div>\r\n    <div class=\"movie-desc\">\r\n        <p>");
            EndContext();
            BeginContext(276, 17, false);
#line 12 "C:\Users\Stefan\Desktop\Academy\MVC\MyBlog\MyBlog\Views\Blog\Details.cshtml"
      Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(293, 40, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        <p>");
            EndContext();
            BeginContext(334, 10, false);
#line 15 "C:\Users\Stefan\Desktop\Academy\MVC\MyBlog\MyBlog\Views\Blog\Details.cshtml"
      Write(Model.Text);

#line default
#line hidden
            EndContext();
            BeginContext(344, 28, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyBlog.Models.Blog> Html { get; private set; }
    }
}
#pragma warning restore 1591
