using System.Collections.Generic;
using System.Linq;
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
            Task.Run(() => ConvertFileToBytes(TraverseFiles(path)));

        public Task<string> LoadStringAt(string path) =>
            Task.Run(
                () => path.Split('/').Aggregate<string, object>(
                    Files,
                    (currentFile, key) =>
                        ((Dictionary<string, object>)currentFile)
                        [key]) as string);
    }
}