using System;
using System.Collections.Generic;
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
            => TraverseFilesByParts(path.Split('/'));
        
        private object TraverseFilesByParts(IEnumerable<string> parts)
        {
            object current = Files;
            foreach (string part in parts)
                current = ((DummyDirectory)current)[part];
            return current;
        }

        public Task<string> LoadStringAt(string path) =>
            Task.Run(
                () => ConvertFileToString(TraverseFiles(path)));

        private static byte[] ConvertFileToBytes(object fileContents) =>
            fileContents is string s ?
                Encoding.Default.GetBytes(s) :
                fileContents as byte[];

        private static string ConvertFileToString(object fileContents) =>
            fileContents is byte[] bytes ?
                Encoding.Default.GetString(bytes) :
                fileContents as string;

        public void InsertAt(string path, object contents)
        {
            object current = Files;
            string[] segments = path.Split('/');
            ArraySegment<string> dictParts = new ArraySegment<string>(
                segments, 0, segments.Length - 1);
            
            foreach (string part in dictParts)
                if (current is DummyDirectory dir)
                {
                    EnsureDictionary(dir, part);
                    current = dir[part];
                }
                else
                    throw new NotImplementedException();

            ((DummyDirectory)current)[segments[segments.Length - 1]] = contents;
        }

        private static void EnsureDictionary(DummyDirectory dir, string part)
        {
            if (!dir.ContainsKey(part))
                dir[part] = new DummyDirectory();
        }
    }
}