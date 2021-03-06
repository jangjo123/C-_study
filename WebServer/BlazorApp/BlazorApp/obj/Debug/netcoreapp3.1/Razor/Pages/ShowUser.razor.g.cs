#pragma checksum "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "561bb2c598ba4d0b87cac88154f6e3040ebdfdc5"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
using BlazorApp.Data;

#line default
#line hidden
#nullable disable
    public partial class ShowUser : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "p");
            __builder.AddMarkupContent(1, "\r\n    Users: ");
            __builder.OpenElement(2, "b");
            __builder.AddContent(3, 
#nullable restore
#line 4 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
               Users.Count()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n<br>\r\n\r\n");
            __builder.OpenComponent<BlazorApp.Pages.Counter>(6);
            __builder.CloseComponent();
            __builder.AddMarkupContent(7, "\r\n\r\n");
            __builder.OpenElement(8, "ul");
            __builder.AddAttribute(9, "class", "list-group");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 12 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
     foreach (UserData user in Users)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "        ");
            __builder.OpenElement(12, "li");
            __builder.AddAttribute(13, "class", "list-group-item");
            __builder.SetKey(
#nullable restore
#line 14 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
                  user

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(14, "\r\n            ");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "type", "button");
            __builder.AddAttribute(17, "class", "btn btn-link");
            __builder.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
                                                                 () => KickUser(user)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(19, "Kick");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n            ");
            __builder.OpenElement(21, "label");
            __builder.AddAttribute(22, "style", "color:" + " " + (
#nullable restore
#line 16 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
                                  _color

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(23, 
#nullable restore
#line 16 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
                                           user.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n");
#nullable restore
#line 18 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\ShowUser.razor"
       
    [CascadingParameter (Name = "ThemeColor")]
    string _color { get; set; }

    [Parameter]
    public List<UserData> Users { get; set; }

    [Parameter]
    public EventCallback CallbackTest { get; set; }

    protected override void OnInitialized()
    {
        Users.Add(new UserData() { Name = "User1" });
        Users.Add(new UserData() { Name = "User2" });
        Users.Add(new UserData() { Name = "User3" });
    }

    public void AddUser(UserData user)
    {
        Users.Add(user);
    }

    public void KickUser(UserData user)
    {
        Users.Remove(user);

        CallbackTest.InvokeAsync(null);
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
