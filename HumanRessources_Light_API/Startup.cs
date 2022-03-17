using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Repositories;
using HumanRessources_Light_API.Services;
using HumanRessources_Light_API.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace HumanRessources_Light_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuring the Authentification service
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.Configure<DbSettings>(options =>
            {
               options.ConnectionString = Configuration.GetSection("DatabaseSettings:CONNECTION_STRING").Value;
               options.DatabaseName = Configuration.GetSection("DatabaseSettings:DATABASENAME").Value;
            });

            // Injecting the MongoDbContext as single shared instance
            services.AddSingleton<IDbContext, MongoDbContext>();

            // Injecting the repositories & services 
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IGenericService<Role>, RoleService>();
            services.AddScoped<IRepository<Administrator>, AdministratorRepository>();
            services.AddScoped<IGenericService<Administrator>, AdministratorService>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IGenericService<Employee>, EmployeeService>();
            services.AddScoped<IRepository<Department>, DepartmentRepository>();
            services.AddScoped<IGenericService<Department>, DepartmentService>();
            services.AddScoped<IRepository<Account>, AccountRepository>();
            services.AddScoped<IGenericService<Account>, AccountService>();
            services.AddScoped<RegistrationService>();
            services.AddScoped<AuthentificationService>();

            // Injecting the controllers
            services.AddControllers();

            // Adding the swagger
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Human Ressources Light API",
                    Version = "v1",
                    Description = "Light implementation of a HR system",
                    Contact = new OpenApiContact
                    {
                        Name = "WARID Khalil",
                        Email = "khalil.warid@gmail.com",
                        Url = new Uri("https://github.com/WARIDKhalil/HumanRessources_Light"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Human Ressources Light API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
