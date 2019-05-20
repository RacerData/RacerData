using System;
using Newtonsoft.Json;
using RacerData.Common.Ports;

namespace RacerData.Common.Adapters
{
    class Serializer : ISerializer
    {
        #region fields

        private readonly IFileService _fileService = null;

        #endregion

        #region ctor

        public Serializer(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        #endregion

        #region public

        public string Serialize<T>(T item)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var json = JsonConvert.SerializeObject(
                    item,
                    Formatting.Indented,
                    settings);

            return json;
        }

        public T Deserialize<T>(string json) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void SerializeToFile<T>(T item, string fileName)
        {
            var json = Serialize<T>(item);

            _fileService.WriteFile(fileName, json);
        }

        public T DeserializeFromFile<T>(string fileName) where T : class, new()
        {
            var json = _fileService.ReadFile(fileName);

            return Deserialize<T>(json);
        }

        public T DeepCopy<T>(T obj) where T : class, new()
        {
            if (!typeof(T).IsSerializable)
                throw new Exception("The source object must be serializable");

            if (Object.ReferenceEquals(obj, null))
                throw new Exception("The source object must not be null");

            T result = default(T);

            var json = Serialize<T>(obj);

            result = Deserialize<T>(json);

            return result;
        }

        #endregion
    }
}
