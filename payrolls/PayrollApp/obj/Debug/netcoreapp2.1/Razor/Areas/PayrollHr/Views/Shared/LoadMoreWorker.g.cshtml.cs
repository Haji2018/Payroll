#pragma checksum "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75f3d5fcd8ab4c78e8e283c2ac9d0898e64cc61f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PayrollHr_Views_Shared_LoadMoreWorker), @"mvc.1.0.view", @"/Areas/PayrollHr/Views/Shared/LoadMoreWorker.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/PayrollHr/Views/Shared/LoadMoreWorker.cshtml", typeof(AspNetCore.Areas_PayrollHr_Views_Shared_LoadMoreWorker))]
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
#line 3 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\_ViewImports.cshtml"
using PayrollApp.Models.ForIdentity;

#line default
#line hidden
#line 4 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75f3d5fcd8ab4c78e8e283c2ac9d0898e64cc61f", @"/Areas/PayrollHr/Views/Shared/LoadMoreWorker.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68e536b9eda31527d455fece58723f852c31ef7", @"/Areas/PayrollHr/Views/_ViewImports.cshtml")]
    public class Areas_PayrollHr_Views_Shared_LoadMoreWorker : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PayrollApp.Models.Employment.Worker>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditWorker", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger deleteWorker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
            EndContext();
#line 6 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
            BeginContext(98, 38, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n\r\n            ");
            EndContext();
            BeginContext(137, 48, false);
#line 11 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Employee.Name));

#line default
#line hidden
            EndContext();
            BeginContext(185, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(200, 51, false);
#line 12 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Employee.Surname));

#line default
#line hidden
            EndContext();
            BeginContext(251, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(295, 50, false);
#line 15 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Store.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(345, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(389, 56, false);
#line 18 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Position.PositionName));

#line default
#line hidden
            EndContext();
            BeginContext(445, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(489, 60, false);
#line 21 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.PastPosition.PositionName));

#line default
#line hidden
            EndContext();
            BeginContext(549, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(593, 44, false);
#line 24 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(637, 45, true);
            WriteLiteral("\r\n        </td>\r\n\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(683, 60, false);
#line 28 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Department.DepartmentName));

#line default
#line hidden
            EndContext();
            BeginContext(743, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(787, 54, false);
#line 31 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Company.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(841, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(884, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e8049b8fc3940fe9b7506a1e625ed77", async() => {
                BeginContext(960, 27, true);
                WriteLiteral("<i class=\"fas fa-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 34 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
                                                                  WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(991, 16, true);
            WriteLiteral("\r\n\r\n            ");
            EndContext();
            BeginContext(1007, 157, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3dadce5ceed4f55be6a40e888c331ef", async() => {
                BeginContext(1127, 28, true);
                WriteLiteral("<i class=\"fas fa-trash\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
                                   WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 36 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
                                                             Write(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1164, 30, true);
            WriteLiteral("\r\n\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
            BeginContext(1198, 100, true);
            WriteLiteral("    <tr class=\"d-none\" id=\"trEmployee\">\r\n\r\n\r\n        <td>\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1299, 50, false);
#line 48 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Store.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(1349, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1393, 56, false);
#line 51 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Position.PositionName));

#line default
#line hidden
            EndContext();
            BeginContext(1449, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1493, 60, false);
#line 54 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.PastPosition.PositionName));

#line default
#line hidden
            EndContext();
            BeginContext(1553, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1597, 44, false);
#line 57 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(1641, 45, true);
            WriteLiteral("\r\n        </td>\r\n\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1687, 60, false);
#line 61 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Department.DepartmentName));

#line default
#line hidden
            EndContext();
            BeginContext(1747, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1791, 54, false);
#line 64 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
       Write(Html.DisplayFor(modelItem => item.Company.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(1845, 47, true);
            WriteLiteral("\r\n        </td>\r\n\r\n        <td>\r\n\r\n            ");
            EndContext();
            BeginContext(1892, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "587a1bcc26b142fa8470208b79dd3605", async() => {
                BeginContext(1968, 27, true);
                WriteLiteral("<i class=\"fas fa-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 69 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
                                                                  WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1999, 16, true);
            WriteLiteral("\r\n\r\n            ");
            EndContext();
            BeginContext(2015, 163, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64c849206c25492fae6c201a5a131312", async() => {
                BeginContext(2135, 34, true);
                WriteLiteral("<i class=\"fas fa-trash\"></i>Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 71 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
                                   WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 71 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
                                                             Write(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2178, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 74 "C:\Users\MAMMADLI\Desktop\payrolls - Copy\PayrollApp\Areas\PayrollHr\Views\Shared\LoadMoreWorker.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PayrollApp.Models.Employment.Worker>> Html { get; private set; }
    }
}
#pragma warning restore 1591