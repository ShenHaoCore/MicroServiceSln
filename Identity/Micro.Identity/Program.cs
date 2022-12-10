using IdentityServer4;
using IdentityServer4.Test;
using Micro.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddTestUsers(TestUsers.Users);

builder.Services.AddAuthentication().AddLocalApi(options =>
{
    options.ExpectedScope = "api";
}).AddOpenIdConnect("AAD", "Sign-in with Azure AD", options =>
{
    options.Authority = "https://login.microsoftonline.com/common";
    options.ClientId = "https://leastprivilegelabs.onmicrosoft.com/38196330-e766-4051-ad10-14596c7e97d3";
    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
    options.ResponseType = "id_token";
    options.CallbackPath = "/signin-aad";
    options.SignedOutCallbackPath = "/signout-callback-aad";
    options.RemoteSignOutPath = "/signout-aad";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidAudience = "165b99fd-195f-4d93-a111-3e679246e6a9",
        NameClaimType = "name",
        RoleClaimType = "role"
    };
}).AddGoogle("Google", "Sign-in with Google", options =>
{
    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
    options.ClientId = "ClientId";
    options.ClientSecret = "ClientSecret";
});

// 在缓存中保留 OIDC 状态（解决 AAD 和 URL 长度的问题）
// preserve OIDC state in cache (solves problems with AAD and URL lenghts)
builder.Services.AddOidcStateDataFormatterCache("aad");

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
