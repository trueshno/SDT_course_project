namespace Domain.Helpers.Interfaces
{
    public interface IParseHelper
    {
        bool FileExist(string filePath);
        bool IsNull(object? entity);
    }
}
