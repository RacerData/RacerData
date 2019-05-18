namespace RacerData.rNascarApp.Services
{
    public interface IFileService
    {
        bool AppendFile(string filePath, string fileContent);
        string ReadFile(string filePath);
        bool WriteFile(string filePath, string fileContent);
    }
}