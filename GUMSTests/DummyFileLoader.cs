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
            return Task.Run(
                () =>
                {
                    switch (pathSegments.Length)
                    {
                        case 3:
                            return
                                ((Dictionary<string, object>)
                                    ((Dictionary<string, object>)
                                        Files[pathSegments[0]])
                                    [pathSegments[1]])
                                [pathSegments[2]] as string;
                        case 2:
                            return
                                ((Dictionary<string, object>)
                                    Files[pathSegments[0]])
                                [pathSegments[1]] as string;
                        default: 
                            return
                                Files[path] as string;
                    }
                });
        }
    }
}