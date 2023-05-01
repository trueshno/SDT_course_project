using Domain.Helpers.Interfaces;

namespace Domain.Helpers.Implementations
{
    public class ParseHelper : IParseHelper
    {
        public bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public bool IsNull(object? entity)
        {
            return entity == null;
        }
    }
}
