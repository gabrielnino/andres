using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Api.Insttantt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddResponseCompression();
            services.AddDbContext<DataAccess.Common.MainContext>(options =>
                                                  options
                                                   .UseSqlServer(this.GetConnection)
                                                   .UseLazyLoadingProxies());
            services.AddScoped<DataAccess.Common.Interfaces.IMainContext>(provider => provider.GetService<DataAccess.Common.MainContext>());

            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
                    .AddJsonOptions(options => options.JsonSerializerOptions.MaxDepth = int.MaxValue);

            services.AddTransient<BusinessRules.Interfaces.IFields, BusinessRules.BusinessRules.Fields>();
            services.AddTransient<DataAccess.Interfaces.IFields, DataAccess.Dao.Fields>();

            services.AddTransient<BusinessRules.Interfaces.IFlows, BusinessRules.BusinessRules.Flows>();
            services.AddTransient<DataAccess.Interfaces.IFlows, DataAccess.Dao.Flows>();

            services.AddTransient<BusinessRules.Interfaces.ISecuences, BusinessRules.BusinessRules.Secuences>();
            services.AddTransient<DataAccess.Interfaces.ISecuences, DataAccess.Dao.Secuences>();

            services.AddTransient<BusinessRules.Interfaces.ISteps, BusinessRules.BusinessRules.Steps>();
            services.AddTransient<DataAccess.Interfaces.ISteps, DataAccess.Dao.Steps>();

            services.AddTransient<BusinessRules.Interfaces.IStepsInFields, BusinessRules.BusinessRules.StepsInFields>();
            services.AddTransient<DataAccess.Interfaces.IStepsInFields, DataAccess.Dao.StepsInFields>();

            services.AddTransient<BusinessRules.Interfaces.IStepsNext, BusinessRules.BusinessRules.StepsNext>();
            services.AddTransient<DataAccess.Interfaces.IStepsNext, DataAccess.Dao.StepsNext>();

            services.AddTransient<BusinessRules.Interfaces.IFlowGeneral, BusinessRules.BusinessRules.FlowGeneral>();


            services.AddTransient<BusinessRules.Interfaces.IUsers,BusinessRules.BusinessRules.Users> ();
            services.AddTransient<DataAccess.Interfaces.IUsers, DataAccess.Dao.Users>();

            services.AddTransient<BusinessRules.Interfaces.IFieldsByUser, BusinessRules.BusinessRules.FieldsByUser>();
            services.AddTransient<DataAccess.Interfaces.IFieldsByUser, DataAccess.Dao.FieldsByUser>();

            services.AddTransient<BusinessRules.Interfaces.ITypeFields, BusinessRules.BusinessRules.TypeFields>();
            services.AddTransient<DataAccess.Interfaces.ITypeFields, DataAccess.Dao.TypeFields>();

            AddSwagger(services);
            this.CreateDBContext<DataAccess.Common.Interfaces.IMainContext, DataAccess.Common.MainContext>(services, this.GetConnection);
            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
                    .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreReadOnlyProperties = true)
                    .AddJsonOptions(options => options.JsonSerializerOptions.MaxDepth = int.MaxValue)
                    .ConfigureApiBehaviorOptions(option =>
                    {
                        option.InvalidModelStateResponseFactory = actionContext => GetInvalidModalState(actionContext);
                    });
        }

        public static IActionResult GetInvalidModalState(ActionContext actionContext)
        {
            var modalState = actionContext.ModelState.Values;
            return new BadRequestObjectResult(modalState);
        }

        protected void CreateDBContext<TService, TContext>(IServiceCollection services, string conection)
           where TContext : DbContext, TService
           where TService : class
        {
            CreateDBContext<TService, TContext>(services, conection, true);
        }
        protected void CreateDBContext<TService, TContext>(IServiceCollection services, string conection, bool lazyLoading)
           where TContext : DbContext, TService
           where TService : class
        {
            services.AddDbContext<TContext>(options =>
                                                  options
                                                  .UseSqlServer(conection)
                                                  .UseLazyLoadingProxies(lazyLoading));

            services.AddScoped<TService>(provider => provider.GetService<TContext>());
        }
        protected void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllParametersInCamelCase();

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Ejemplo: 'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng...'",
                    Name = "Autorización " + "EndpointDescription",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },  new List<string>()
                      }
                    });

                swagger.SwaggerDoc("v1", GetApiInfo);

                swagger.DocInclusionPredicate((docName, description) => true);
                swagger.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.XML");
                swagger.IncludeXmlComments(xmlPath);
            });
        }
        protected OpenApiInfo GetApiInfo => new OpenApiInfo
        {
            Title = "Hubbec -Api - Let's make life easier for end users.",
            Version = "v1",
            Description = "Api.Insttantt - Web API in ASP.NET Core 3.1 - ® Hubbec 2021 ",
            Contact = new OpenApiContact() { Email = "lnino@Insttantt.com" }
        };
        protected string GetConnection => Configuration.GetConnectionString("DefaultConnection");

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataAccess.Common.MainContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API-Insttantt");
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }
    }
}
