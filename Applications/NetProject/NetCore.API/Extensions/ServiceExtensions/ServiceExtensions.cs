using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Contracts.UnitOfWork;
using NetCore.Business.Logic.UnitOfWork;
using NetCore.Contracts.Logger;
using NetCore.Services.Logger;
using NetCore.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCore.Data.Access.DataAccessModels.Dashboards;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System;
using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetCoreAPI.Extensions.ServiceExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build());
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config["mysqlconnection:connectionString"];
            //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
            //services.AddDbContext<RepositoryContext>(options =>
            //options.UseSqlServer("DataBaseContext"));
            var connectionString = config["DataBaseContextSQL:connectionString"];
            services.AddDbContext<DashboardsContext>(o => o.UseSqlServer(connectionString));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["DataBaseContextMySQL:connectionString"];
            services.AddDbContext<DataAccessContext>(o => o.UseMySql(connectionString));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthenticationJWT(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ApiDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "eDashboardAPI",
                    Version = "v1",
                    Description = "IT NCR CHIH",
                    TermsOfService = "JABIL",
                    Contact = new Contact
                    {
                        Name = "Luis Raúl Espinoza Barboza",
                        Email = "luis_espinoza6@jabil.com",
                        // Url = "https://twitter.com/spboyer"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });            
        }

        
    }
}
