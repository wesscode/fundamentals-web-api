using ApiFuncional.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//AddControllers: habilita api com estrutura controller
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true; //Ignora as validações do AspNet dataAnnotations
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//IdentityUser: usuário logado(usuario interativo)
//IdentityRole: perfil do usuário logado.
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>() //definindo que o sistema deve usar roles
                .AddEntityFrameworkStores<ApiDbContext>(); //definindo contexto para o identity

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers(); //habilita api com estrutura controller

app.Run();