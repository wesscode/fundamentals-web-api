namespace ApiFuncional.Configuration
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            //AddControllers: habilita api com estrutura controller
            builder.Services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressModelStateInvalidFilter = true; //Ignora as validações do AspNet dataAnnotations
                    });

            return builder;
        } 
    }
}
