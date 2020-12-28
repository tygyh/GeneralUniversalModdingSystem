using System;
using System.Threading.Tasks;

namespace GeneralUniversalModdingSystem
{
    public interface IFileLoader
    {
        // This interface needs to be able to load files in a safe way
        String BasePath {get;}
        Task<byte[]> LoadAt(String path);
        Task<String> LoadStringAt(String path);
    }
}