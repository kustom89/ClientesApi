using ClienteApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CLientesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB")));

// 👇 Agregar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 👇 Usar CORS aquí
app.UseCors("PermitirFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
