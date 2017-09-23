using System.IO;
using System.Linq;

namespace Thrifty.IntegrationTests
{
    public class Utilities
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