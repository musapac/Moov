#pragma checksum "C:\Workspace\Github\Moov\Moov-WebApplication-Project\Views\Moov\HelloWorld.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5976989b485f8ed4baf2fb0f9071fc20f211c047"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Moov_HelloWorld), @"mvc.1.0.view", @"/Views/Moov/HelloWorld.cshtml")]
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
#line 1 "C:\Workspace\Github\Moov\Moov-WebApplication-Project\Views\_ViewImports.cshtml"
using Moov_WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Workspace\Github\Moov\Moov-WebApplication-Project\Views\_ViewImports.cshtml"
using Moov_WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5976989b485f8ed4baf2fb0f9071fc20f211c047", @"/Views/Moov/HelloWorld.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b80c3fb93496ab5ad89387cbedf6e5cf30c4ca", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Moov_HelloWorld : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Workspace\Github\Moov\Moov-WebApplication-Project\Views\Moov\HelloWorld.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<script src=\'https://code.jquery.com/jquery-3.6.0.min.js\' integrity=\'sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=\' crossorigin=\'anonymous\'></script>\r\n");
            WriteLiteral(@"<script>
     $(document).ready(function () {  
             
                $.ajax({  
                    type: ""GET"",
                    url : ""https://api.moov.io/tos-token"",
                     headers: {
                         ""Accept"":""application/json"",
                         ""Content-Type"":""application/json"",
                         ""Origin"":""https://api.moov.io"",
                         ""Referer"": 'https://api.moov.io'
                     }, 
                    dataType: 'json',  
                    success: function (response) {  
                    console.log('SUCCUSS : ' + response);
                    var tosToken= response.token;
                    abc(tosToken)
                             
                     }
                    });
                });
</script>
<script>
    function abc(tostoken){
 $.ajax({
         data: tostoken,
         type: ""post"",
         url: ""helloworld?tok=""+tostoken,
         contenttype: ""application/json; charset=u");
            WriteLiteral("tf-8\",         \r\n         datatype: \"text\",\r\n         success: function (response) {\r\n             \r\n           \r\n         },\r\n         error: function (result) {\r\n             alert(\'oh no :(\');\r\n         }\r\n     });   \r\n\r\n    }\r\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
