using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Thrifty.IntegrationTests
{
    public class ApplicationShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public ApplicationShould()
        {
            var setDir = Utilities.TryGetSolutionDirectoryInfo() + "\\src\\Thrifty.Web";

            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(setDir)
                .UseStartup<TestStartup>());

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
