using Microsoft.EntityFrameworkCore;
using ProyectoLibros.Components;
using ProyectoLibros.Components.Clases;
using ProyectoLibros.Components.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexion a MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ConexionSQL"),
        new MySqlServerVersion(new Version(8, 0, 23))));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// se agrega inyeccion de dependencias 
builder.Services.AddScoped<IRepositorio, Repositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
