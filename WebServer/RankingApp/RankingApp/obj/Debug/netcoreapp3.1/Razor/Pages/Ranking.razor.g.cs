#pragma checksum "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4810c3c7772d5a3aceb4a86484776d1b0a26750f"
// <auto-generated/>
#pragma warning disable 1591
namespace RankingApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using RankingApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\_Imports.razor"
using RankingApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
using ShareData.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
using RankingApp.Data.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ranking")]
    public partial class Ranking : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Ranking</h3>\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(1);
            __builder.AddAttribute(2, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(3, "\r\n");
#nullable restore
#line 11 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
         if (_gameResults == null)
        {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(4, "            ");
                __builder2.AddMarkupContent(5, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 14 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(6, "            ");
                __builder2.OpenElement(7, "table");
                __builder2.AddAttribute(8, "class", "table");
                __builder2.AddMarkupContent(9, "\r\n                ");
                __builder2.AddMarkupContent(10, @"<thead>
                    <tr>
                        <th>UserName</th>
                        <th>Score</th>
                        <th>Date</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                ");
                __builder2.OpenElement(11, "tbody");
                __builder2.AddMarkupContent(12, "\r\n");
#nullable restore
#line 28 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                     foreach (var gameResult in _gameResults)
                    {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(13, "                    ");
                __builder2.OpenElement(14, "tr");
                __builder2.AddMarkupContent(15, "\r\n                        ");
                __builder2.OpenElement(16, "td");
                __builder2.AddContent(17, 
#nullable restore
#line 31 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                             gameResult.UserName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(18, "\r\n                        ");
                __builder2.OpenElement(19, "td");
                __builder2.AddContent(20, 
#nullable restore
#line 32 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                             gameResult.Score

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n                        ");
                __builder2.OpenElement(22, "td");
                __builder2.AddContent(23, 
#nullable restore
#line 33 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                             gameResult.DateTime.ToString()

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n                        ");
                __builder2.OpenElement(25, "td");
                __builder2.AddMarkupContent(26, "\r\n                            ");
                __builder2.OpenElement(27, "button");
                __builder2.AddAttribute(28, "class", "btn btn-primary");
                __builder2.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                                      () => UpdateGameResult(gameResult)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(30, "Edit");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(32, "\r\n                        ");
                __builder2.OpenElement(33, "td");
                __builder2.AddMarkupContent(34, "\r\n                            ");
                __builder2.OpenElement(35, "button");
                __builder2.AddAttribute(36, "class", "btn btn-primary");
                __builder2.AddAttribute(37, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                                      () => DeleteGameResult(gameResult)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(38, "Delete");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n");
#nullable restore
#line 41 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(42, "                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(44, "\r\n");
                __builder2.AddContent(45, "            ");
                __builder2.OpenElement(46, "p");
                __builder2.AddMarkupContent(47, "\r\n                ");
                __builder2.OpenElement(48, "button");
                __builder2.AddAttribute(49, "class", "btn btn-primary");
                __builder2.AddAttribute(50, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 46 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                          AddGameResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(51, "\r\n                    Add\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n");
#nullable restore
#line 51 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
             if (_showPopup)
            {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(54, "                ");
                __builder2.OpenElement(55, "div");
                __builder2.AddAttribute(56, "class", "modal");
                __builder2.AddAttribute(57, "style", "display:block");
                __builder2.AddAttribute(58, "role", "dialog");
                __builder2.AddMarkupContent(59, "\r\n                    ");
                __builder2.OpenElement(60, "div");
                __builder2.AddAttribute(61, "class", "modal-dialog");
                __builder2.AddMarkupContent(62, "\r\n                        ");
                __builder2.OpenElement(63, "div");
                __builder2.AddAttribute(64, "class", "modal-content");
                __builder2.AddMarkupContent(65, "\r\n                            ");
                __builder2.OpenElement(66, "div");
                __builder2.AddAttribute(67, "class", "modal-header");
                __builder2.AddMarkupContent(68, "\r\n                                ");
                __builder2.AddMarkupContent(69, "<h3 class=\"modal-title\">Add/Update GameResult</h3>\r\n                                ");
                __builder2.OpenElement(70, "button");
                __builder2.AddAttribute(71, "type", "button");
                __builder2.AddAttribute(72, "class", "close");
                __builder2.AddAttribute(73, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 58 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                                              ClosePopup

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(74, "\r\n                                    ");
                __builder2.AddMarkupContent(75, "<span area-hidden=\"true\">X</span>\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(77, "\r\n                            ");
                __builder2.OpenElement(78, "div");
                __builder2.AddAttribute(79, "class", "modal-body");
                __builder2.AddMarkupContent(80, "\r\n                                ");
                __builder2.AddMarkupContent(81, "<label for=\"UserName\">UserName</label>\r\n                                ");
                __builder2.OpenElement(82, "input");
                __builder2.AddAttribute(83, "class", "form-control");
                __builder2.AddAttribute(84, "type", "text");
                __builder2.AddAttribute(85, "placeholder", "UserName");
                __builder2.AddAttribute(86, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 64 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                                                                            _gameResult.UserName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(87, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _gameResult.UserName = __value, _gameResult.UserName));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n                                ");
                __builder2.AddMarkupContent(89, "<label for=\"Score\">Score</label>\r\n                                ");
                __builder2.OpenElement(90, "input");
                __builder2.AddAttribute(91, "class", "form-control");
                __builder2.AddAttribute(92, "type", "text");
                __builder2.AddAttribute(93, "placeholder", "Score");
                __builder2.AddAttribute(94, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 66 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                                                                         _gameResult.Score

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(95, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _gameResult.Score = __value, _gameResult.Score));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(96, "\r\n                                ");
                __builder2.OpenElement(97, "button");
                __builder2.AddAttribute(98, "class", "btn btn-primary");
                __builder2.AddAttribute(99, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 67 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
                                                                          SaveGameResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(100, "\r\n                                    Save\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(101, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(102, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(103, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(104, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(105, "\r\n");
#nullable restore
#line 74 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
             
        }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(106, "    ");
            }
            ));
            __builder.AddAttribute(107, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(108, "\r\n        ");
                __builder2.AddMarkupContent(109, "<p>You are not Authorized!</p>\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 85 "D:\Github_jangjo123\C-_study\WebServer\RankingApp\RankingApp\Pages\Ranking.razor"
       

    List<GameResult> _gameResults;

    bool _showPopup;
    GameResult _gameResult;

    protected override async Task OnInitializedAsync()
    {
        _gameResults = await RankingService.GetGameResultsAsync();
    }

    void AddGameResult()
    {
        _showPopup = true;
        _gameResult = new GameResult() { Id = 0 };
    }

    void ClosePopup()
    {
        _showPopup = false;
    }

    void UpdateGameResult(GameResult gameResult)
    {
        _showPopup = true;
        _gameResult = gameResult;
    }

    async Task DeleteGameResult(GameResult gameResult)
    {
        var result = RankingService.DeleteGameResult(_gameResult);
        _gameResults = await RankingService.GetGameResultsAsync();
    }

    async Task SaveGameResult()
    {
        if (_gameResult.Id == 0)
        {
            _gameResult.DateTime = DateTime.Now;
            var result = await RankingService.AddGameResult(_gameResult);
        }
        else
        {
            var result = await RankingService.UpdateGameResult(_gameResult);
        }

        _showPopup = false;
        _gameResults = await RankingService.GetGameResultsAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RankingService RankingService { get; set; }
    }
}
#pragma warning restore 1591
