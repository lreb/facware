using NetCore.Contract.Logger;
using NetCore.Service.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreAPI.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            // https://code-maze.com/net-core-web-development-part3/#configuringLogger

            // By calling services.AddSingleton which will create the service the first time 
            // you request it and then every subsequent request is calling the same instance 
            // of the service. This means that all components are sharing the same service 
            // every time they need it. You are using the same instance always
            services.AddSingleton<ILoggerManager, LoggerManager>();

            // By calling services.AddScoped which will create the service once per request. 
            // That means whenever we send the HTTP request towards the application, a new 
            // instance of the service is created
            //services.AddScoped<ILoggerManager, LoggerManager>();

            // By calling services.AddTransient which will create the service each time 
            // application request it. This means that if during one request towards our 
            // application, multiple components need the service, this service will be 
            // created again for every single component which needs it
            //services.AddTransient<ILoggerManager, LoggerManager>();
        }
    }
}
