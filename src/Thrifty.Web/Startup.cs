using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Thrifty.Abstractions;
using Thrifty.Abstractions.Repositories;
using Thrifty.Abstractions.Services;
using Thrifty.Data;
using Thrifty.Repositories;
using Thrifty.Services;

namespace Thrifty.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            ConfigureApplicationServices(services);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ThriftyDbContext context)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            // todo: refactor below db code to its own initialization class
            if (env.IsDevelopment())
            {
                // Create database if not exists
                context.Database.EnsureCreated();
            }
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ThriftyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("thriftydb")));
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
