#pragma checksum "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollSpecialist\Views\Payment\ListResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "518c99273ad5e9a6da3ee3adb4f5bbc0cb089806"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PayrollSpecialist_Views_Payment_ListResult), @"mvc.1.0.view", @"/Areas/PayrollSpecialist/Views/Payment/ListResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/PayrollSpecialist/Views/Payment/ListResult.cshtml", typeof(AspNetCore.Areas_PayrollSpecialist_Views_Payment_ListResult))]
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
#line 3 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollSpecialist\Views\_ViewImports.cshtml"
using PayrollApp.Models.ForIdentity;

#line default
#line hidden
#line 4 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollSpecialist\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"518c99273ad5e9a6da3ee3adb4f5bbc0cb089806", @"/Areas/PayrollSpecialist/Views/Payment/ListResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68e536b9eda31527d455fece58723f852c31ef7", @"/Areas/PayrollSpecialist/Views/_ViewImports.cshtml")]
    public class Areas_PayrollSpecialist_Views_Payment_ListResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PayrollApp.Models.PayrollSpecialist.SalaryPayment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "PayrollSpecialist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Payment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListPayment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "LoadMoreResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 195, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"Holding col-md-12\">\r\n\r\n    <div class=\"head-holding\">\r\n        <div class=\"row\">\r\n            <p>Maaş Alanların Cədvəli</p>\r\n\r\n\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n    ");
            EndContext();
            BeginContext(266, 470, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "678774ce96f242ec9c9ee6b96535c7af", async() => {
                BeginContext(369, 360, true);
                WriteLiteral(@"

        <div class=""form-group searchIcon  col-xl-4"">
            <i class=""fas fa-search icon""></i>

            <input placeholder=""AXTARIŞ"" name=""SearchString"" class=""form-control searchInput"" type=""text"" style=""border-radius:5rem;"" />
            <button type=""submit"" class=""btn btn-default btn-info hiddenButton""></button>
        </div>

    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(736, 978, true);
            WriteLiteral(@"






    <table class=""table  employees"">

        <thead class=""holdingThread"">
            <tr class=""holdingTr"">
                <th>
                    <h5>İşçi</h5>

                </th>


                <th>

                    <h5>Vəzifə</h5>
                </th>
                <th>

                    <h5>İşçi Bonusu</h5>
                </th>
                <th>

                    <h5>İşçi Cəriməsi </h5>
                </th>

                <th>

                    <h5>Mağaza Bonusu</h5>
                </th>
                <th>

                    <h5>Qayıbların Sayı</h5>
                </th>
                <th>

                    <h5>Məzuniyyətin Sayı</h5>
                </th>
                <th>

                    <h5>Gün</h5>
                </th>
                <th>

                    <h5>Vaktiki Maaş</h5>
                </th>
                <th>


                    ");
            EndContext();
            BeginContext(1714, 201, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75afe4faabba44fd9ab6fc33ffb6c817", async() => {
                BeginContext(1742, 169, true);
                WriteLiteral("\r\n                        <button title=\"Siyahı\" type=\"submit\" class=\"btn btn-primary holdingButton\"><i class=\"fas fa-list bigPlus\"></i></button>\r\n\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1915, 142, true);
            WriteLiteral("\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody class=\"table-body table-bordered holdingTbody\">\r\n\r\n            ");
            EndContext();
            BeginContext(2057, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e0a2277195b4458db14831d840a63de9", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#line 94 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollSpecialist\Views\Payment\ListResult.cshtml"
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
            BeginContext(2105, 263, true);
            WriteLiteral(@"






        </tbody>
    </table>

    <div class=""row"">
        <button id=""load_more_result_salary"" style=""border-radius:5rem;"" class=""btn btn-primary w-25 mx-outo my-5 ml-5"">Yüklə</button>

    </div>
    <input type=""hidden"" id=""holdingCount""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2368, "\"", 2395, 1);
#line 108 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollSpecialist\Views\Payment\ListResult.cshtml"
WriteAttributeValue("", 2376, ViewBag.TotalCount, 2376, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2396, 669, true);
            WriteLiteral(@" />

</div>



<div class=""modal fade"" id=""delete"">

    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content modal-bg-color"">
            <div class=""modal-header"">
                <h4 class=""ml-5"">Silmək isdədiyinizdən əminsinizmi?</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>

            </div>


            <div class=""modal-footer d-flex"">
                <button type=""button"" class=""btn btn-primary"" data-dismiss=""modal"">
                    <span class=""caption-subject bold"">İmtina </span>
                </button>
                <span class=""AntiForge""> ");
            EndContext();
            BeginContext(3066, 23, false);
#line 129 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollSpecialist\Views\Payment\ListResult.cshtml"
                                    Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(3089, 390, true);
            WriteLiteral(@" </span>
                <button type=""button"" class=""btn btn-danger deleteSave_ResultSalary"" data-dismiss=""modal"">
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PayrollApp.Models.PayrollSpecialist.SalaryPayment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
