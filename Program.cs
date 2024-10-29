using Microsoft.EntityFrameworkCore;
using PersonajesWebAPI;
using PersonajesWebAPI.Models;
using PersonajesWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<PersonajeService>();

builder.Services.AddDbContext<PersonajeDbContext>(dbContextOptions => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
