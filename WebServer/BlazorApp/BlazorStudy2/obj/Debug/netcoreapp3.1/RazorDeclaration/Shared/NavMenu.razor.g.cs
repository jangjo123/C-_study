// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorStudy2.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using BlazorStudy2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\_Imports.razor"
using BlazorStudy2.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "D:\Github_jangjo123\C-_study\WebServer\BlazorApp\BlazorStudy2\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected override void OnInitialized()
    {
        CounterState.OnStateChanged += onStateChanged;
    }

    void onStateChanged()
    {
        this.StateHasChanged();
    }

    void IDisposable.Dispose()
    {
        CounterState.OnStateChanged -= onStateChanged;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorStudy2.Data.CounterState CounterState { get; set; }
    }
}
#pragma warning restore 1591
