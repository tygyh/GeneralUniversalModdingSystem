using System.Collections.Generic;
using System.Threading.Tasks;
using GeneralUniversalModdingSystem;

namespace GUMSTests
{
    public class DummyFileLoader : IFileLoader
    {
        public Dictionary<string, object> Files =
            new Dictionary<string, object>();

        public DummyFileLoader(string basePath) => BasePath = basePath;
        public string BasePath {get;}

        public Task<byte[]> LoadAt(string path) =>
            throw new System.NotImplementedException();

        public Task<string> LoadStringAt(string path)
        {
            string[] pathSegments = path.Split('/');
            string folder = pathSegments[0];

            return Task.Run(
                () => pathSegments.Length == 2 ?
                    ((Dictionary<string, string>)Files[folder])[pathSegments[1]] :
                    Files[path] as string);
        }
    }
}