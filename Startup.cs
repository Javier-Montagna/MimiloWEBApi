using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Mimilo.Database;
using Mimilo.Interfaces;
using Mimilo.Models;
using Microsoft.AspNetCore.Identity;

namespace Mimilo
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddIdentity<MimiloUser, MimiloRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequiredLength = 6,
                    RequireNonAlphanumeric = false
                };
            }).AddEntityFrameworkStores<MimiloContext>()
            .AddDefaultTokenProviders();

            services.AddDbContext<MimiloContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MimiloDatabase")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMimiloUserRepository, MimiloUserRepository>();
            services.AddTransient<MimiloSeedData>();
            
            services.AddCors(options => options.AddPolicy("FilterByDomain", 
                                                p => p.WithOrigins("http://localhost:4200", "http://mimilo.azurewebsites.net")
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader())); 
            services.AddMvc()
               .AddViewLocalization()
               .AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, MimiloSeedData seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddConsole();

            var context = app.ApplicationServices.GetService<MimiloContext>();
      
            app.UseCors("FilterByDomain");
            app.UseMvc();
            seeder.EnsureSeedDate().Wait();
        }
    }
}