using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Thrifty.Web;
using Xunit;

namespace Thrifty.IntegrationTests
{
    public class ApplicationShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ApplicationShould()
        {
            // Arrange
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            var setDir = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\..\Thrifty.Web\"));

            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(@"G:\Workspace\thrifty\src\Thrifty.Web")
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task ReturnSuccessCodeOnDefaultPage()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
        }
    }
}
