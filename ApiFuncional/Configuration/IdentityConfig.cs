using ApiFuncional.Data;
using ApiFuncional.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiFuncional.Configuration
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {
            //IdentityUser: usuário logado(usuario interativo)
            //IdentityRole: perfil do usuário logado.
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddRoles<IdentityRole>() //definindo que o sistema deve usar roles
                            .AddEntityFrameworkStores<ApiDbContext>(); //definindo contexto para o identity

            //Pegando o token e gerando a chave encodada.
            var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings"); //obtendo dadaos do appsettings
            builder.Services.Configure<JwtSettings>(JwtSettingsSection); //populando classe com os dados

            var jwtSettings = JwtSettingsSection.Get<JwtSettings>(); //pegando a instância da classe com dados populados.
            var key = Encoding.ASCII.GetBytes("14856197-0b99-40f7-825c-2475a16f211e"); //parse segredo to bytes


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // definindo schema de autenticação
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //válida o token
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true; //Para trabalhar somente em https
                options.SaveToken = true; //Após uma autenticação que deu certo o token é salvo durante a requisição no request.
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key), //gerar chave
                    ValidateIssuer = true, //valiando emissor.
                    ValidateAudience = true, //validando minha audiencia com a que está no token.
                    ValidAudience = jwtSettings.Audiencia, //Informando audiencia.
                    ValidIssuer = jwtSettings.Emissor //Informando Emissor.
                };
            });

            return builder;
        }
    }
}
