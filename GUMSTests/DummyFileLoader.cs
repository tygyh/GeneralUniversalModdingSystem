using System.Collections.Generic;
using System.Threading.Tasks;
using GeneralUniversalModdingSystem;

namespace GUMSTests
{
    public class DummyFileLoader : IFileLoader
    {
        public Dictionary<string,object> Files = new Dictionary<string, object>();
        public DummyFileLoader(string basePath) => BasePath = basePath;
        public string BasePath {get;}
        public Task<byte[]> LoadAt(string path) => throw new System.NotImplementedException();

        public Task<string> LoadStringAt(string path) =>
            Task.Run(() => Files[path] as string);
    }
}