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
#line 3 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\User.razor"
using BlazorApp.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/user")]
    public partial class User : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorApp\Pages\User.razor"
       

    List<UserData> _users = new List<UserData>();

    string _inputName;
    string _btnClass = "btn btn-primary";

    protected override void OnInitialized()
    {
        _users.Add(new UserData() { Name = "User1" });
        _users.Add(new UserData() { Name = "User2" });
        _users.Add(new UserData() { Name = "User3" });
        RefreshButton();
    }

    void AddUser()
    {
        _users.Add(new UserData() { Name = _inputName });
        _inputName = "";
        RefreshButton();
    }

    void KickUser(UserData user)
    {
        _users.Remove(user);
        RefreshButton();
    }

    void RefreshButton()
    {
        if (_users.Count() % 2 == 0)
            _btnClass = "btn btn-primary";
        else
            _btnClass = "btn btn-secondary";
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
