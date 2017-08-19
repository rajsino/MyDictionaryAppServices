using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyDictionaryServices.Data.Profiles;
using Microsoft.EntityFrameworkCore;
using MyDictionaryServices.Queries.Profiles;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyDictionaryServices.Commands.Profiles;
using System.Reflection;
using Swashbuckle.Swagger.Model;
using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Formatters;
using MyDictionaryServices.Queries.PrepareTest;

namespace MyDictionaryServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var constr = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ProfilesDbContext>
                (options => options.UseSqlServer(constr));
            services.AddTransient<IProfileQueries, ProfileQueries>();
            services.AddTransient<IUserQueries, UserQueries>();
            services.AddTransient<ITenantQueries, TenantQueries>();
            services.AddTransient<ITestResultQueries, TestResultQueries>();
            services.AddSingleton<IConfiguration>(Configuration);
            // Add framework services.
            services.AddCors();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .AddMvcOptions(options =>
            {
                options.InputFormatters.Insert(0, new TextPlainInputFormatter());
            });

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "MyDictionary Test API",
                    Description = "Profiles API for Xebia Interview",
                    TermsOfService = "None"
                });
                options.DescribeAllEnumsAsStrings();
            });
            // Plug Autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<ProfilesCommandBus>().As<ICommandBus>();
            // Register CommandHandlers
            builder.RegisterAssemblyTypes(typeof(Startup).GetTypeInfo().Assembly)
                 .AsClosedTypesOf(typeof(ICommandHandler<>))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(b => b.AllowAnyOrigin());
            app.UseSwagger();
            app.UseSwaggerUi();
            app.UseMvc();
        }
    }
}
