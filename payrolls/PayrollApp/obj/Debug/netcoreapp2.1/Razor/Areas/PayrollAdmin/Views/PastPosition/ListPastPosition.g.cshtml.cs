#pragma checksum "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\PastPosition\ListPastPosition.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab35afda19f2c4a3a3655a36ac86d9803e1bc67d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PayrollAdmin_Views_PastPosition_ListPastPosition), @"mvc.1.0.view", @"/Areas/PayrollAdmin/Views/PastPosition/ListPastPosition.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/PayrollAdmin/Views/PastPosition/ListPastPosition.cshtml", typeof(AspNetCore.Areas_PayrollAdmin_Views_PastPosition_ListPastPosition))]
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
#line 3 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\_ViewImports.cshtml"
using PayrollApp.Models.Head;

#line default
#line hidden
#line 4 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\_ViewImports.cshtml"
using PayrollApp.Models.ForIdentity;

#line default
#line hidden
#line 5 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab35afda19f2c4a3a3655a36ac86d9803e1bc67d", @"/Areas/PayrollAdmin/Views/PastPosition/ListPastPosition.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"999ef64df79cbb1fd7e33c2615fbfb22c9cbcc7d", @"/Areas/PayrollAdmin/Views/_ViewImports.cshtml")]
    public class Areas_PayrollAdmin_Views_PastPosition_ListPastPosition : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PayrollApp.Models.Employment.PastPosition>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePastPosition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListPastPosition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "LoadMorePastPosition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(65, 935, true);
            WriteLiteral(@"

<div class=""Holding col-md-12"">

    <div class=""head-holding"">
        <div class=""row"">

            <p> Vəzifə Üzrə Əməliyyatlar</p>



        </div>

    </div>


    <div class=""form-group searchIcon  col-xl-4"">
        <i class=""fas fa-search icon""></i>
        <input id=""pastpositionName"" placeholder=""AXTARIŞ"" class=""form-control searchInput"" type=""text"" style=""border-radius:5rem;"" />
    </div>








    <table class=""table  employees"">

        <thead class=""holdingThread"">
            <tr class=""holdingTr"">
                <th>
                    <h5>Vəzifə</h5>
                </th>
                <th>
                    <h5>Maaş</h5>
                </th>
                <th>
                    <h5>Departament</h5>
                </th>
                <th>
                    <h5>Şirkət</h5>
                </th>

                <th>
                    ");
            EndContext();
            BeginContext(1000, 211, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81c693a17f9c4565959932bb642f6743", async() => {
                BeginContext(1035, 172, true);
                WriteLiteral("\r\n                        <button title=\"Əlavə Et\" type=\"submit\" class=\"btn btn-primary holdingButton\"><i class=\"fa fa-plus bigPlus\"></i>  </button>\r\n\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1211, 24, true);
            WriteLiteral("\r\n\r\n                    ");
            EndContext();
            BeginContext(1235, 206, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "856c5b89af5a45b4801a5027c31c29d8", async() => {
                BeginContext(1268, 169, true);
                WriteLiteral("\r\n                        <button title=\"Siyahı\" type=\"submit\" class=\"btn btn-primary holdingButton\"><i class=\"fas fa-list bigPlus\"></i></button>\r\n\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1441, 140, true);
            WriteLiteral("\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody class=\"table-body table-bordered holdingTbody\">\r\n            ");
            EndContext();
            BeginContext(1581, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "366938c94554447b96dfcfa87049df3c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 63 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\PastPosition\ListPastPosition.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1634, 253, true);
            WriteLiteral("\r\n\r\n        </tbody>\r\n    </table>\r\n\r\n    <div class=\"row\">\r\n        <button id=\"load_more_past_position\" style=\"border-radius:5rem;\" class=\"btn btn-primary w-25 mx-outo my-5 ml-5\">Yüklə</button>\r\n\r\n    </div>\r\n    <input type=\"hidden\" id=\"holdingCount\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1887, "\"", 1914, 1);
#line 72 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\PastPosition\ListPastPosition.cshtml"
WriteAttributeValue("", 1895, ViewBag.TotalCount, 1895, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1915, 675, true);
            WriteLiteral(@" />
</div>


<div class=""modal fade"" id=""delete"">

    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content modal-bg-color"">
            <div class=""modal-header"">
                <h5 class=""ml-5"">Silmək isdədiyinizdən əminsinizmi?</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>

            </div>
          

            <div class=""modal-footer d-flex"">
                <button type=""button"" class=""btn btn-primary"" data-dismiss=""modal"">
                    <span class=""caption-subject bold"">İmtina </span>
                </button>
                <span class=""AntiForge""> ");
            EndContext();
            BeginContext(2591, 23, false);
#line 91 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollAdmin\Views\PastPosition\ListPastPosition.cshtml"
                                    Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2614, 388, true);
            WriteLiteral(@" </span>
                <button type=""button"" class=""btn btn-danger deleteSave_PastPosition"" data-dismiss=""modal"">
                    <i class=""fas fa-trash text-white m-r-5""></i>
                    <span class=""caption-subject bold ml-2"">
                        Sil
                    </span>
                </button>
            </div>
        </div>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PayrollApp.Models.Employment.PastPosition>> Html { get; private set; }
    }
}
#pragma warning restore 1591
