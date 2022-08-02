using Serilog;

namespace CustomerMinimalApiWS.EndpointDefinitions
{
    public static class BuildConfiguration
    {
        public static void ConfigureBuilder(this WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(builder.Configuration)
                .Enrich
                .FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
        }
        public static void ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
