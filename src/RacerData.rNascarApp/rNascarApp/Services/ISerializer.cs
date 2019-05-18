namespace RacerData.rNascarApp.Services
{
    public interface ISerializer
    {
        T Deserialize<T>(string json) where T : class, new();
        T DeserializeFromFile<T>(string fileName) where T : class, new();
        string Serialize<T>(T item);
        void SerializeToFile<T>(T item, string fileName);
        T DeepCopy<T>(T obj) where T : class, new();
    }
}