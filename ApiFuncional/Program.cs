using ApiFuncional.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //habilita api com estrutura controller
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoint minimal
app.MapGet("/weatherforecast", () => "Teste")
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseAuthorization();

app.MapControllers(); //habilita api com estrutura controller

app.Run();