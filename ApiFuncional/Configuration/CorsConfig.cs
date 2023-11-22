namespace ApiFuncional.Configuration
{
    public static class CorsConfig
    {
        public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
        {
            //Definindo e implementando CORS
            builder.Services.AddCors(options =>
            {
                //politicas de CORS
                options.AddPolicy("Development", builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

                options.AddPolicy("Production", builder =>
                            builder
                                .WithOrigins("https://localhost:9000")
                                .WithOrigins("POST")
                                .AllowAnyHeader());
            });

            return builder;
        }
    }
}
