#pragma checksum "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18878084a14a7e28c8447e7fb5b3cb357e57c287"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_Submissions), @"mvc.1.0.view", @"/Views/Professor/Submissions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/Submissions.cshtml", typeof(AspNetCore.Views_Professor_Submissions))]
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
#line 1 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18878084a14a7e28c8447e7fb5b3cb357e57c287", @"/Views/Professor/Submissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_Submissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
  
    ViewData["Title"] = "Submissions";
    Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(104, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(114, 936, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18878084a14a7e28c8447e7fb5b3cb357e57c2874115", async() => {
                BeginContext(120, 923, true);
                WriteLiteral(@"
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style>
    body {
      font-family: ""Lato"", sans-serif;
    }

    .sidenav {
      /*width: 130px;
      height: 210px;
      position: fixed;
      z-index: 1;
      top: 80px;
      left: 10px;*/
      width: 130px;
      height: 210px;
      position: fixed;
      left: 0;
      right: 0;
      /*margin-left: auto;
      margin-right: auto;*/
      z-index: 1;
      top: 50px;

      background: #eee;
      overflow-x: hidden;
      padding: 8px 0;
    }

      .sidenav a {
        padding: 6px 8px 6px 16px;
        text-decoration: none;
        font-size: 18px;
        color: #2196F3;
        display: block;
      }

        .sidenav a:hover {
          color: #064579;
        }

    .main {
      margin-left: 140px;
      min-height: 200px;
      padding: 0px 10px;
    }
  </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1050, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1052, 1349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18878084a14a7e28c8447e7fb5b3cb357e57c2876227", async() => {
                BeginContext(1058, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1093, "\'", 1216, 8);
                WriteAttributeValue("", 1100, "/Professor/Class?subject=", 1100, 25, true);
#line 59 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1125, ViewData["subject"], 1125, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1145, "&num=", 1145, 5, true);
#line 59 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1150, ViewData["num"], 1150, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1166, "&season=", 1166, 8, true);
#line 59 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1174, ViewData["season"], 1174, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1193, "&year=", 1193, 6, true);
#line 59 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1199, ViewData["year"], 1199, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1217, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1241, "\'", 1367, 8);
                WriteAttributeValue("", 1248, "/Professor/Students?subject=", 1248, 28, true);
#line 60 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1276, ViewData["subject"], 1276, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1296, "&num=", 1296, 5, true);
#line 60 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1301, ViewData["num"], 1301, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1317, "&season=", 1317, 8, true);
#line 60 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1325, ViewData["season"], 1325, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1344, "&year=", 1344, 6, true);
#line 60 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1350, ViewData["year"], 1350, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1368, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1389, "\'", 1517, 8);
                WriteAttributeValue("", 1396, "/Professor/Categories?subject=", 1396, 30, true);
#line 61 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1426, ViewData["subject"], 1426, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1446, "&num=", 1446, 5, true);
#line 61 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1451, ViewData["num"], 1451, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1467, "&season=", 1467, 8, true);
#line 61 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1475, ViewData["season"], 1475, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1494, "&year=", 1494, 6, true);
#line 61 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
WriteAttributeValue("", 1500, ViewData["year"], 1500, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1518, 876, true);
                WriteLiteral(@">Assignment Categories</a>
  </div>


  <div class=""main"">
    <h4 id=""classname"">Class</h4>

    <div id=""departmentDiv"" class=""col-md-12"">
    <div class=""panel panel-primary"">
      <div class=""panel-heading"">
        <h3 class=""panel-title"">Submissions</h3>
      </div>
      <div class=""panel-body"">
        <table id=""tblSubmissions"" class=""table table-bordered table-striped table-responsive table-hover"">
          <thead>
            <tr>
              <th align=""left"" class=""productth"">Name</th>
              <th align=""left"" class=""productth"">uID</th>
              <th align=""left"" class=""productth"">Time</th>
              <th align=""left"" class=""productth"">Score</th>
              <th align=""left"" class=""productth"">Submission</th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>

  </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2401, 21, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2443, 996, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");


      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.lname + "", "" + item.fname));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.uid));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.time));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.score));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
        a.setAttribute(""href"", ""/Professor/Grade/?subject="" + '");
                EndContext();
                BeginContext(3440, 19, false);
#line 128 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                          Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3459, 15, true);
                WriteLiteral("\' + \"&num=\" + \'");
                EndContext();
                BeginContext(3475, 15, false);
#line 128 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                                                             Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3490, 18, true);
                WriteLiteral("\' + \"&season=\" + \'");
                EndContext();
                BeginContext(3509, 18, false);
#line 128 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                                                                                               Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3527, 16, true);
                WriteLiteral("\' + \"&year=\" + \'");
                EndContext();
                BeginContext(3544, 16, false);
#line 128 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                                                                                                                                  Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3560, 15, true);
                WriteLiteral("\' + \"&cat=\" + \'");
                EndContext();
                BeginContext(3576, 15, false);
#line 128 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                                                                                                                                                                  Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(3591, 17, true);
                WriteLiteral("\' + \"&aname=\" + \'");
                EndContext();
                BeginContext(3609, 17, false);
#line 128 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                                                                                                                                                                                                   Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(3626, 291, true);
                WriteLiteral(@"' + ""&uid="" + item.uid);
        a.appendChild(document.createTextNode(""view""));
        td.appendChild(a);
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      classname.innerText = '");
                EndContext();
                BeginContext(3918, 19, false);
#line 142 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                        Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3937, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3939, 15, false);
#line 142 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                             Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3954, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3956, 18, false);
#line 142 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3974, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3976, 16, false);
#line 142 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                                                                                  Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3992, 121, true);
                WriteLiteral("\';\r\n\r\n      var tbl = document.getElementById(\"tblSubmissions\");\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(4114, 53, false);
#line 148 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
         Write(Url.Action("GetSubmissionsToAssignment", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(4167, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(4236, 19, false);
#line 151 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(4255, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(4283, 15, false);
#line 152 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(4298, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(4323, 18, false);
#line 153 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(4341, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(4370, 16, false);
#line 154 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(4386, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(4413, 15, false);
#line 155 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(4428, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(4453, 17, false);
#line 156 "C:\Users\Logan\Downloads\LMS_handout2\LMS\Views\Professor\Submissions.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(4470, 327, true);
                WriteLiteral(@"'},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          PopulateTable(tbl, data);

        },
          error: function (ex) {
              alert(""GetSubmissionsToAssignment controller did not return successfully"");
        }
        });

        
    }

  </script>

");
                EndContext();
            }
            );
            BeginContext(4800, 4, true);
            WriteLiteral("\r\n\r\n");
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
