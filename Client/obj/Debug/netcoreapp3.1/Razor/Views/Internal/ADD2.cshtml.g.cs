#pragma checksum "D:\DATA\MCC\ResourcePlacement\Client\Views\Internal\ADD2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd080c5da1ded27b8d4034a04419adbcccfda3cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Internal_ADD2), @"mvc.1.0.view", @"/Views/Internal/ADD2.cshtml")]
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
#line 1 "D:\DATA\MCC\ResourcePlacement\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DATA\MCC\ResourcePlacement\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd080c5da1ded27b8d4034a04419adbcccfda3cb", @"/Views/Internal/ADD2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Internal_ADD2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/rpms/images/logo/logo1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/employee.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/rpms/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\DATA\MCC\ResourcePlacement\Client\Views\Internal\ADD2.cshtml"
  
    ViewData["Title"] = "RPMS - Staff";
    Layout = "_InternalLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd080c5da1ded27b8d4034a04419adbcccfda3cb4873", async() => {
                WriteLiteral("\r\n    <nav class=\"navbar navbar-light\">\r\n        <div class=\"container d-block\">\r\n            <a class=\"navbar-brand ms-4\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cd080c5da1ded27b8d4034a04419adbcccfda3cb5282", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </a>
        </div>
    </nav>
    <div class=""col-12 col-md-11 order-md-2 order-first"">
        <nav aria-label=""breadcrumb"" class=""breadcrumb-header float-start float-lg-end"">
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item font-extrabold""><a>Hi, Client &nbsp;</a></li>
                <li class=""sidebar-item "" type=""button"" data-bs-toggle=""modal"" data-bs-target="".modalChangePassword"">
                    <a class='sidebar-link'>
                        <i class=""bi bi-gear""></i>
                    </a>
                </li>
            </ol>
        </nav>
    </div>


    <div class=""container"">
        <div class=""card mt-5"">
            <div class=""card-header"">
                <h4 class=""card-title"">Single Layout</h4>
            </div>
            <div class=""card-body"">
                <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Possimus nemo quasi labore expedita?
                    Veritatis");
                WriteLiteral("\n                    at maxime id voluptates excepturi molestiae possimus blanditiis dicta consequuntur maiores suscipit,\r\n                    eveniet neque obcaecati doloribus.\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
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
            WriteLiteral(@"


<!--<div id=""app"">
    <div id=""sidebar"" class=""active"">
        <div class=""sidebar-wrapper active"">
            <div class=""sidebar-header"">
                <div class=""d-flex justify-content-between"">
                    <div class=""logo"">
                        <a><img src=""~/rpms/images/logo/logo1.png"" alt=""Logo"" srcset=""""></a>
                    </div>
                    <div class=""toggler"">
                        <a href=""#"" class=""sidebar-hide d-xl-none d-block""><i class=""bi bi-x bi-middle""></i></a>
                    </div>
                </div>
            </div>
            <div class=""sidebar-menu"">
                <ul class=""menu"">
                    <li class=""sidebar-item "">
                        <a href=""");
#nullable restore
#line 67 "D:\DATA\MCC\ResourcePlacement\Client\Views\Internal\ADD2.cshtml"
                            Write(Url.Content("~/Internal/Trainer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class='sidebar-link'>
                            <i class=""bi bi-grid-fill""></i>
                            <span>Main</span>
                        </a>
                    </li>
                    <li class=""sidebar-item"" type=""button"" data-bs-toggle=""modal"" data-bs-target="".modalAddParticipant"">
                        <a class='sidebar-link'>
                            <i class=""bi bi-plus-circle""></i>
                            <span>Add Participant</span>
                        </a>
                    </li>
                    <li class=""sidebar-item "" type=""button"" data-bs-toggle=""modal"" data-bs-target="".modalChangePassword"">
                        <a class='sidebar-link'>
                            <i class=""bi bi-gear""></i>
                            <span>Change Password</span>
                        </a>
                    </li>
                </ul>
            </div>
            <button class=""sidebar-toggler btn x""><i data-feather=""x""></i></button>
        </di");
            WriteLiteral("v>\r\n    </div>-->\r\n\r\n");
            WriteLiteral(@"    <!--<div class=""modal fade text-left modalAddParticipant"" id=""modalAddParticipant"" tabindex=""-1"" role=""dialog""
         aria-labelledby=""myModalLabel17"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered modal-dialog-scrollable modal-lg""
             role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""myModalLabel17"">Add Participant</h4>
                    <button type=""button"" class=""close"" data-bs-dismiss=""modal""
                            aria-label=""Close"">
                        <i data-feather=""x""></i>
                    </button>
                </div>
                <div class=""modal-body"">-->
");
            WriteLiteral(@"                    <!--<div class=""row match-height"">
                        <div class=""col-12"">
                            <div class=""card"">
                                <div class=""card-content"">
                                    <div class=""card-body"">
                                        <form class=""form"">
                                            <div class=""row"">
                                                <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""first-name-column"">First Name</label>
                                                        <input type=""text"" id=""first-name-column"" class=""form-control""
                                                               placeholder=""First Name"" name=""fname-column"">
                                                    </div>
                                                </div>
                   ");
            WriteLiteral(@"                             <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""last-name-column"">Last Name</label>
                                                        <input type=""text"" id=""last-name-column"" class=""form-control""
                                                               placeholder=""Last Name"" name=""lname-column"">
                                                    </div>
                                                </div>
                                                <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""email-id-column"">Email</label>
                                                        <input type=""email"" id=""email-id-column"" class=""form-control""
                                                             ");
            WriteLiteral(@"  name=""email-id-column"" placeholder=""Email"">
                                                    </div>
                                                </div>
                                                <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""city-column"">Gender</label>
                                                        <div class=""form-check"">
                                                            <input class=""form-check-input"" type=""radio"" name=""flexRadioDefault""
                                                                   id=""flexRadioDefault1"">
                                                            <label class=""form-check-label"" for=""flexRadioDefault1"">
                                                                Pria
                                                            </label>
                                             ");
            WriteLiteral(@"           </div>
                                                        <div class=""form-check"">
                                                            <input class=""form-check-input"" type=""radio"" name=""flexRadioDefault""
                                                                   id=""flexRadioDefault2"" checked>
                                                            <label class=""form-check-label"" for=""flexRadioDefault2"">
                                                                Wanita
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""country-floating"">Phone Numb");
            WriteLiteral(@"er</label>
                                                        <input type=""text"" id=""country-floating"" class=""form-control""
                                                               name=""country-floating"" placeholder=""PhoneNumber"">
                                                    </div>
                                                </div>
                                                <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""birthdate"">Birthdate</label>
                                                        <input type=""date"" id=""birthdate"" class=""form-control""
                                                               name=""birthdate"" placeholder=""dd/mm/yyyy"">
                                                    </div>
                                                </div>
                                                <div class=""col-md-6 col");
            WriteLiteral(@"-12"">
                                                    <div class=""form-group"">
                                                        <label for=""grade"">Grade</label>
                                                        <input type=""text"" id=""grade"" class=""form-control""
                                                               name=""grade"" placeholder=""A"">
                                                    </div>
                                                </div>
                                                <div class=""col-md-6 col-12"">
                                                    <div class=""form-group"">
                                                        <label for=""skills"">Skills</label>
                                                        <select class=""choices form-select multiple-remove""
                                                                multiple=""multiple"">
                                                            <optgroup label=""Figures"">");
            WriteLiteral(@"
                                                                <option value=""romboid"">Romboid</option>
                                                                <option value=""trapeze"" selected>Trapeze</option>
                                                                <option value=""triangle"">Triangle</option>
                                                                <option value=""polygon"">Polygon</option>
                                                            </optgroup>
                                                            <optgroup label=""Colors"">
                                                                <option value=""red"">Red</option>
                                                                <option value=""green"">Green</option>
                                                                <option value=""blue"" selected>Blue</option>
                                                                <option value=""purple"">Purple</option>
               ");
            WriteLiteral(@"                                             </optgroup>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-success ml-1""
                            data-bs-dismiss=""modal"">
                        <i class=""bx bx-check d-block d-sm-none""></i>
                        <span class=""d-none d-sm-block"">Submit</span>
                    </button>
                    <button type=""button"" class=""btn btn-light-secondary""
                            data-bs-dismiss=""modal"">
      ");
            WriteLiteral("                  <i class=\"bx bx-x d-block d-sm-none\"></i>\r\n                        <span class=\"d-none d-sm-block\">Close</span>\r\n                    </button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>-->\r\n\r\n");
            WriteLiteral(@"    <!--<div class=""modal fade text-left modalChangePassword"" id=""modalChangePassword"" tabindex=""-1""
         role=""dialog"" aria-labelledby=""myModalLabel18"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered modal-dialog-scrollable""
             role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""myModalLabel18"">
                        Change Password
                    </h4>
                    <button type=""button"" class=""close"" data-bs-dismiss=""modal""
                            aria-label=""Close"">
                        <i data-feather=""x""></i>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""col-md-12 col-8"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <form class=""form form-horizontal"">
                    ");
            WriteLiteral(@"                <div class=""form-body"">
                                        <div class=""row"">
                                            <div class=""col-md-4"">
                                                <label>Email</label>
                                            </div>
                                            <div class=""col-md-8 form-group"">
                                                <input type=""email"" id=""email-id"" class=""form-control""
                                                       name=""email-id"" placeholder=""Email"">
                                            </div>
                                            <div class=""col-md-4"">
                                                <label>Old Password</label>
                                            </div>
                                            <div class=""col-md-8 form-group"">
                                                <input type=""password"" id=""oldPassword"" class=""form-control""
                    ");
            WriteLiteral(@"                                   name=""oldPassword"" placeholder=""Old Password"">
                                            </div>
                                            <div class=""col-md-4"">
                                                <label>New Password</label>
                                            </div>
                                            <div class=""col-md-8 form-group"">
                                                <input type=""password"" id=""newPassword"" class=""form-control""
                                                       name=""newPassword"" placeholder=""New Password"">
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" class=""bt");
            WriteLiteral(@"n btn-primary ml-1""
                            data-bs-dismiss=""modal"">
                        <i class=""bx bx-check d-block d-sm-none""></i>
                        <span class=""d-none d-sm-block"">Change Password</span>
                    </button>
                    <button type=""button"" class=""btn btn-light-secondary""
                            data-bs-dismiss=""modal"">
                        <i class=""bx bx-x d-block d-sm-none""></i>
                        <span class=""d-none d-sm-block"">Close</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div id=""main"">
        <header class=""mb-3"">
            <a href=""#"" class=""burger-btn d-block d-xl-none"">
                <i class=""bi bi-justify fs-3""></i>
            </a>
        </header>

        <div class=""page-heading"">
            <div class=""page-title"">
                <div class=""row"">
                    <div class=""col-12 col-md-6 order-md-1 order-last mb-5 font-e");
            WriteLiteral(@"xtrabold"">
                        <h2>Staff Area</h2>
                    </div>
                    <div class=""col-12 col-md-6 order-md-2 order-first"">
                        <nav aria-label=""breadcrumb"" class=""breadcrumb-header float-start float-lg-end"">
                            <ol class=""breadcrumb"">
                                <li class=""breadcrumb-item font-extrabold""><a>Hi, Staff</a></li>
                            </ol>
                        </nav>
                    </div>
                </div>
                <hr />
            </div>
            <div class=""row"">
            </div>
            <section class=""section"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h3>Participant Lists</h3>
                        <p>Recommended Participant Lists by Trainer</p>
                    </div>
                    <div class=""card-body"">
                        <table class=""table table-striped"" id=""table1"">
 ");
            WriteLiteral(@"                           <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Email</th>
                                    <th>Grade</th>
                                    <th>Status</th>
                                    <th>Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>
        </div>

    </div>
</div>

<script src=""~/rpms/vendors/perfect-scrollbar/perfect-scrollbar.min.js""></script>
<script src=""~/rpms/js/bootstrap.bundle.min.js""></script>

<script src=""~/rpms/vendors/choices.js/choices.min.js""></script>

<script src=""~/rpms/vendors/simple-datatables/simple-datatables.js""></script>
<script>
    // Simple Datatable
    let table1 = document.querySelector('#table1');
    let ");
            WriteLiteral("dataTable = new simpleDatatables.DataTable(table1);\r\n</script>-->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd080c5da1ded27b8d4034a04419adbcccfda3cb27035", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd080c5da1ded27b8d4034a04419adbcccfda3cb28222", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
