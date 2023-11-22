using ApiFuncional.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfig()
        .AddCorsConfig()
        .AddSwaggerConfig()
        .AddDbContextConfig()
        .AddIdentityConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

//Endpoint minimal
app.MapGet("/weatherforecast", () => "Teste")
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers(); //habilita api com estrutura controller

app.Run();