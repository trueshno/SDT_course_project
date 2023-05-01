using Domain.Helper.Interfaces;
using System.IO;

namespace Domain.Helper.Implementations
{
    public class Parser : IParser
    {
        public bool FileExist(string path)
        {
            return File.Exists(path);
        }
    }
}
