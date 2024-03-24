using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OnlineMarket.UI.Authentication;
using OnlineMarket.UI.Client.Pages;
using OnlineMarket.UI.Components;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<IAuthenticationHttpService, AuthenticationHttpService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseAddress"]!);
});

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    p => p.GetRequiredService<ApiAuthenticationStateProvider>()
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(OnlineMarket.UI.Client._Imports).Assembly);

app.Run();
