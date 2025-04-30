using BlazorApp1;
using BlazorApp1.Components;
using BlazorApp1.Data;
using BlazorApp1.Data.Auth;
using BlazorApp1.Data.Services;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Servicios de Blazor
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => options.DetailedErrors = true);
builder.Services.AddAuthorizationCore();

// Servicios personalizados
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddSingleton<TokenContainer>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<PersonajeService>();
builder.Services.AddSingleton<Consumer>();
//builder.Services.AddBlazoredSessionStorage();

// Registro de AuthenticationStateProvider personalizado
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

var app = builder.Build();

// Configuración de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Enrutamiento
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();