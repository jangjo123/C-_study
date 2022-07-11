// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
