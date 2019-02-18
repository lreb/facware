using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Contracts.UnitOfWork;
using NetCore.Business.Logic.UnitOfWork;
using NetCore.Contracts.Logger;
using NetCore.Services.Logger;
using NetCore.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config["mysqlconnection:connectionString"];
            //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
            //services.AddDbContext<RepositoryContext>(options =>
            //options.UseSqlServer("DataBaseContext"));
            var connectionString = config["DataBaseContext:connectionString"];
            services.AddDbContext<DataAccessContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
