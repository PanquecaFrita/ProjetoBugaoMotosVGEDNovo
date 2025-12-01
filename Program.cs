using AppBugaoMotoFVLE.Components;
using AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registro das dependências (singleton e scoped)
builder.Services.AddSingleton<Conexao>();
builder.Services.AddSingleton<FornecedorDAO>();
builder.Services.AddScoped<ClienteDAO>();
builder.Services.AddScoped<ProdutoDAO>();
builder.Services.AddScoped<ServicoDAO>();

// Adiciona suporte para Controllers e Views (para utilizar Controllers de Ação)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Roteamento para Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configuração dos Razor Components (se necessário para sua aplicação)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Inicia a aplicação
app.Run();
