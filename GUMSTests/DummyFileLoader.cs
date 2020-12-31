using System;
using System.Text;
using System.Threading.Tasks;
using GeneralUniversalModdingSystem;
using DummyDirectory = System.Collections.Generic.Dictionary<string, object>;

namespace GUMSTests
{
    public class DummyFileLoader : IFileLoader
    {
        public readonly DummyDirectory Files = new DummyDirectory();

        public DummyFileLoader(string basePath) => BasePath = basePath;
        public string BasePath {get;}

        public Task<byte[]> LoadAt(string path) =>
            Task.Run(() => ConvertFileToBytes(TraverseFiles(path)));

        private object TraverseFiles(string path)
        {
            object current = Files;
            foreach (string part in path.Split('/'))
                current = ((DummyDirectory)current)[part];
            return current;
        }

        public Task<string> LoadStringAt(string path) =>
            Task.Run(
                () => ConvertFileToString(TraverseFiles(path)));

        private static byte[] ConvertFileToBytes(object fileContents) =>
            fileContents as byte[];

        private static string ConvertFileToString(object fileContents) =>
            fileContents is byte[] bytes ?
                Encoding.Default.GetString(bytes) :
                fileContents as string;

        public void InsertAt(string path, object contents)
        {
            object current = Files;
            string[] segments = path.Split('/');

            foreach (string part in new ArraySegment<string>(
                segments, 0, segments.Length - 1))
                if (current is DummyDirectory dir)
                {
                    if (!dir.ContainsKey(part))
                        dir[part] = new DummyDirectory();
                    current = dir[part];
                }
                else
                    throw new NotImplementedException();

            ((DummyDirectory)current)[segments[segments.Length - 1]] = contents;
        }
    }
}