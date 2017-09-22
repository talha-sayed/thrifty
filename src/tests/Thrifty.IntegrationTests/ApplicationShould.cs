using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
            var setDir = Utils.TryGetSolutionDirectoryInfo() + "\\src\\Thrifty.Web";

            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(setDir)
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

    public class Utils
    {
        public static string TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory?.FullName;
        }
    }
}
