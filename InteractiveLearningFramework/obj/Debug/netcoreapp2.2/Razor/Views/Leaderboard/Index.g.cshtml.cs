#pragma checksum "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\Leaderboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e992994dce95d001899ae74bc5bd775b4b4ebde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leaderboard_Index), @"mvc.1.0.view", @"/Views/Leaderboard/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Leaderboard/Index.cshtml", typeof(AspNetCore.Views_Leaderboard_Index))]
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
#line 1 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\_ViewImports.cshtml"
using InteractiveLearningFramework;

#line default
#line hidden
#line 2 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\_ViewImports.cshtml"
using InteractiveLearningFramework.Models;

#line default
#line hidden
#line 3 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\_ViewImports.cshtml"
using InteractiveLearningFramework.ViewModels;

#line default
#line hidden
#line 4 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\_ViewImports.cshtml"
using InteractiveLearningFramework.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\_ViewImports.cshtml"
using InteractiveLearningFramework.Models.ManageViewModels;

#line default
#line hidden
#line 6 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\_ViewImports.cshtml"
using InteractiveLearningFramework.Views.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e992994dce95d001899ae74bc5bd775b4b4ebde", @"/Views/Leaderboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ac79eb029c6d767b2353da98c3f2ef7a75d3c2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Leaderboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\Leaderboard\Index.cshtml"
  
    ViewData["Title"] = "Index";
     ViewData.AddActivePage(ManageNavPages.Leaderboard);

#line default
#line hidden
            BeginContext(101, 125, true);
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        Leaderboard\r\n    </div>\r\n    <div class=\"card-body\">\r\n\r\n        ");
            EndContext();
            BeginContext(226, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e992994dce95d001899ae74bc5bd775b4b4ebde4882", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 13 "C:\project\CourseManagement-master\InteractiveLearningFramework\Views\Leaderboard\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(292, 2402, true);
            WriteLiteral(@"

        <table class=""table table-condensed table-bordered table-striped"">
            <tr>
                <th>Rank</th>
                <th>Name</th>
                <th>Points</th>
                <th>
                    Badges
                </th>

                
            </tr>


            <tr>
                <td>1</td>
                <td>Nayana Shrestha</td>
                <td>1125</td>
                <td>
                    <i class=""fa fa-diamond"" aria-hidden=""true""></i>
                </td>

            </tr>
            <tr>
                <td>2</td>
                <td>Alex Shrestha</td>
                <td>1050</td>
                <td>
                    <i class=""fa fa-diamond"" aria-hidden=""true""></i>
                </td>


            </tr>
            <tr>
                <td>3</td>
                <td>Rujwol Shrestha</td>
                <td>910</td>
                <td>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>");
            WriteLiteral(@"
                </td>


            </tr>
            <tr>
                <td>4</td>
                <td>Ronisha Shigdel</td>
                <td>790</td>
                <td>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                </td>


            </tr>
            <tr>
                <td>5</td>
                <td>Ashmita Phuyal</td>
                <td>600</td>
                <td>
                    <i class=""fa fa-star-half-o"" aria-hidden=""true""></i>
                </td>



            </tr>
            <tr>
                <td>6</td>
                <td>Ganesh Karki</td>
                <td>352</td>
                <td>
                    <i class=""fa fa-star-half"" aria-hidden=""true""></i>
                </td>


            </tr>
            <tr>
                <td>7</td>
                <td>Sandeep Gautam</td>
                <td>331</td>
                <td>
                    <i class=""fa fa-star-half"" aria-hidden=""true""></");
            WriteLiteral(@"i>
                </td>



            </tr>
            <tr>
                <td>8</td>
                <td>Tohfa Niraula</td>
                <td>210</td>
                <td>
                    <i class=""fa fa-thumbs-up"" aria-hidden=""true""></i>
                </td>


            </tr>

        </table>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
