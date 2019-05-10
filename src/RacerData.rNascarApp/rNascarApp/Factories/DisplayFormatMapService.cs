using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Factories
{
    public class DisplayFormatMapService
    {
        #region fields

        private string _directory = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\settings\\";
        private string _mapFileName = "displayFormatMap.json";
        private string _formatsFileName = "displayFormats.json";

        #endregion

        #region properties

        private IDictionary<ViewDataMember, ViewDisplayFormat> _map;
        public IDictionary<ViewDataMember, ViewDisplayFormat> Map
        {
            get
            {
                if (_map == null)
                    _map = new Dictionary<ViewDataMember, ViewDisplayFormat>();

                return _map;
            }
            set
            {
                _map = value;
            }
        }

        private IList<ViewDisplayFormat> _formats;
        public IList<ViewDisplayFormat> DisplayFormats
        {
            get
            {
                if (_formats == null)
                    _formats = new List<ViewDisplayFormat>();

                return _formats;
            }
            set
            {
                _formats = value;
            }
        }

        #endregion

        #region ctor

        public DisplayFormatMapService()
        {
            Map = LoadMap();
            DisplayFormats = LoadDisplayFormats();
        }

        #endregion

        #region public

        public void Save()
        {
            foreach (ViewDisplayFormat format in Map.Values.ToList())
            {
                var existing = DisplayFormats.FirstOrDefault(f => f.Name == format.Name);

                if (existing == null)
                {
                    DisplayFormats.Add(format);
                }
                else
                {
                    Map.Where(m => m.Value.Name == format.Name);
                }
            }

            SaveMap();
            SaveFormats();
        }

        public virtual void AddNewFormatToMap(ViewDataMember member, ViewDisplayFormat format)
        {
            DisplayFormats.Add(format);
            Map[member] = format;
        }

        #endregion

        #region protected

        protected virtual void SaveMap()
        {
            var filePath = GetMapFilePath();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var mapItems = new List<DataFormatMapItem>();

            foreach (var item in Map)
            {
                mapItems.Add(new DataFormatMapItem()
                {
                    DataMember = item.Key,
                    DisplayFormat = item.Value
                });
            }

            var content = JsonConvert.SerializeObject(
                    mapItems,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(filePath, content);
        }

        protected virtual void SaveFormats()
        {
            var filePath = GetFormatFilePath();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var content = JsonConvert.SerializeObject(
                    this.DisplayFormats,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(filePath, content);
        }

        protected virtual string GetMapFilePath()
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            return Path.Combine(_directory, _mapFileName);
        }

        protected virtual string GetFormatFilePath()
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            return Path.Combine(_directory, _formatsFileName);
        }

        protected virtual IList<ViewDisplayFormat> LoadDisplayFormats()
        {
            IList<ViewDisplayFormat> formats = null;
            string filePath = string.Empty;

            try
            {
                filePath = GetFormatFilePath();

                if (!File.Exists(filePath))
                {
                    return new List<ViewDisplayFormat>();
                }

                var json = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(json))
                {
                    ViewDisplayFormatFactory factory = new ViewDisplayFormatFactory();
                    formats = factory.GetViewDisplayFormats();
                }
                else
                {
                    formats = JsonConvert.DeserializeObject<List<ViewDisplayFormat>>(json);

                    if (formats.Count == 0)
                    {
                        ViewDisplayFormatFactory factory = new ViewDisplayFormatFactory();
                        formats = factory.GetViewDisplayFormats();
                    }
                }
            }
            catch (JsonSerializationException ex)
            {
                throw new System.Exception($"Error deserializing the Display Format file:\r\n\r\n{ex.Message}\r\n\r\n" +
                    $"File: {filePath}", ex);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error loading Display Format Mapping file", ex);
            }

            return formats;
        }

        protected virtual IDictionary<ViewDataMember, ViewDisplayFormat> LoadMap()
        {
            string filePath = string.Empty;

            try
            {
                filePath = GetMapFilePath();

                if (!File.Exists(filePath))
                {
                    SaveMap();

                    return Map;
                }

                var json = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(json))
                {
                    return new Dictionary<ViewDataMember, ViewDisplayFormat>();
                }
                else
                {
                    var mapItems = JsonConvert.DeserializeObject<List<DataFormatMapItem>>(json);

                    var mapDictionary = new Dictionary<ViewDataMember, ViewDisplayFormat>();

                    foreach (var item in mapItems)
                    {
                        mapDictionary.Add(item.DataMember, item.DisplayFormat);
                    }

                    return mapDictionary;
                }
            }
            catch (JsonSerializationException ex)
            {
                throw new System.Exception($"Error deserializing the Display Format Mapping file:\r\n\r\n{ex.Message}\r\n\r\n" +
                    $"File: {filePath}", ex);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error loading Display Format Mapping file", ex);
            }
        }

        #endregion
    }
}
