#pragma checksum "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b993cccd49a7236caf9ffa2ba481455608c2fba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category_Index))]
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
#line 1 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\_ViewImports.cshtml"
using MvcCore;

#line default
#line hidden
#line 2 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\_ViewImports.cshtml"
using Exam.CoreData.Models.Accounts;

#line default
#line hidden
#line 3 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\_ViewImports.cshtml"
using Exam.CoreData.Models.PagingInfo;

#line default
#line hidden
#line 4 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\_ViewImports.cshtml"
using Exam.CoreData.Models.Categories;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b993cccd49a7236caf9ffa2ba481455608c2fba", @"/Areas/Admin/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c944928372905a1d74a86a8132b2daace82b1a89", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BaseSearchResult<CategoryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 1268, true);
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-lg-12"">
        <h1 class=""page-header"">Tables</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                DataTables Advanced Tables
            </div>
            <!-- /.panel-heading -->
            <div class=""panel-body"">
                <table width=""100%"" class=""table table-striped table-bordered table-hover"" id=""dataTables-example"">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Alias</th>
                            <th>CreatedDate</th>
                            <th>Status date</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Id</th>
                            ");
            WriteLiteral("<th>Name</th>\r\n                            <th>Alias</th>\r\n                            <th>CreatedDate</th>\r\n                            <th>Status</th>\r\n                        </tr>\r\n                    </tfoot>\r\n                    <tbody>\r\n");
            EndContext();
#line 44 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                         foreach (var item in Model.Records)
                        {

#line default
#line hidden
            BeginContext(1499, 89, true);
            WriteLiteral("                            <tr class=\"odd gradeX\">\r\n                                <td>");
            EndContext();
            BeginContext(1589, 7, false);
#line 47 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1596, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1640, 9, false);
#line 48 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                               Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1649, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1693, 10, false);
#line 49 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                               Write(item.Alias);

#line default
#line hidden
            EndContext();
            BeginContext(1703, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1748, 79, false);
#line 50 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                                Write(item.CreatedDate.HasValue ? @item.CreatedDate.Value.ToString("dd/MM/yyyy") : "");

#line default
#line hidden
            EndContext();
            BeginContext(1828, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1873, 38, false);
#line 51 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                                Write(item.Status.Value ? "Active" : "Block");

#line default
#line hidden
            EndContext();
            BeginContext(1912, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 53 "C:\Users\hung\Desktop\Đồ án các môn Kỳ I - 2018\CommonRepo\NewCoreProject\MvcCore\Areas\Admin\Views\Category\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(1981, 927, true);
            WriteLiteral(@"
                    </tbody>
                </table>
                <!-- /.table-responsive -->
                <div class=""well"">
                    <h4>DataTables Usage Information</h4>
                    <p>DataTables is a very flexible, advanced tables plugin for jQuery. In SB Admin, we are using a specialized version of DataTables built for Bootstrap 3. We have also customized the table headings to use Font Awesome icons in place of images. For complete documentation on DataTables, visit their website at <a target=""_blank"" href=""https://datatables.net/"">https://datatables.net/</a>.</p>
                    <a class=""btn btn-default btn-lg btn-block"" target=""_blank"" href=""https://datatables.net/"">View DataTables Documentation</a>
                </div>
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->
</div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BaseSearchResult<CategoryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
