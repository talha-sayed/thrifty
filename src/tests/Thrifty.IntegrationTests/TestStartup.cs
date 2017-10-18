using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Thrifty.Abstractions;
using Thrifty.Data;
using Thrifty.Web;

namespace Thrifty.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {

        }

        protected override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ThriftyDbContext>(options => options.UseInMemoryDatabase("ThriftyDB"));
        }
    }
}
