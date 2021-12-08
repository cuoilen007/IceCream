#pragma checksum "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6d6eb3bd11e352b82011cdc140fc684c155b957"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Book_ShowBooks), @"mvc.1.0.view", @"/Areas/Admin/Views/Book/ShowBooks.cshtml")]
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
#line 1 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\_ViewImports.cshtml"
using IceCreamClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\_ViewImports.cshtml"
using IceCreamClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6d6eb3bd11e352b82011cdc140fc684c155b957", @"/Areas/Admin/Views/Book/ShowBooks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea3f2abc2d066c16db197338c0ab209ca0ace109", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Book_ShowBooks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IceCreamClient.Models.BookIceCream>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
  
    ViewData["Title"] = "ShowBooks";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>ShowBooks</h1>

<!-- page title area start -->
<div class=""page-title-area"">
    <div class=""row align-items-center"">
        <div class=""col-sm-6"">
            <div class=""breadcrumbs-area clearfix"">
                <h4 class=""page-title pull-left"">Dashboard</h4>
                <ul class=""breadcrumbs pull-left"">
                    <li><a href=""index.html"">Home</a></li>
                    <li><span>Books</span></li>
                </ul>
            </div>
        </div>
        <div class=""col-sm-6 clearfix"">
            <div class=""user-profile pull-right"">
                <img class=""avatar user-thumb"" src=""assets/images/author/avatar.png"" alt=""avatar"">
                <h4 class=""user-name dropdown-toggle"" data-toggle=""dropdown"">Kumkum Rai <i class=""fa fa-angle-down""></i></h4>
                <div class=""dropdown-menu"">
                    <a class=""dropdown-item"" href=""#"">Message</a>
                    <a class=""dropdown-item"" href=""#"">Settings</a>
                    <a cla");
            WriteLiteral(@"ss=""dropdown-item"" href=""#"">Log Out</a>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- page title area end -->
<div class=""main-content-inner"">
    <div class=""row"">
        <!-- data table start -->
        <div class=""col-12 mt-5"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""header-title"">Books List</h4>
                    <div class=""data-tables"" id=""Datatables3"">
                        <table class=""table text-center"">
                            <thead class=""bg-light text-capitalize"">
                                <tr>
                                    <th>Book Id</th>
                                    <th>Title</th>
                                    <th>Author</th>
                                    <th>Description</th>
                                    <th>Price</th>
                                    <th>Image</th>
                                    <th>Status</th>
      ");
            WriteLiteral("                              <th>Create At</th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 57 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 60 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.BookId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 61 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 62 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 63 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 64 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 65 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.Image);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 66 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.Active);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 67 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                       Write(item.CreateAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 69 "N:\Programs\Github\IceCream\IceCreamClient\Areas\Admin\Views\Book\ShowBooks.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!-- data table end -->\r\n    </div>\r\n</div>\r\n<!-- main content area end -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IceCreamClient.Models.BookIceCream>> Html { get; private set; }
    }
}
#pragma warning restore 1591