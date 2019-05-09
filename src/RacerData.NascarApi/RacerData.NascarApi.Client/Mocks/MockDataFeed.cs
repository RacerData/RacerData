using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    abstract class MockDataFeed<T>
    {
        #region fields

        private readonly IList<T> _data = new List<T>();
        private readonly IResultFactory<INascarApiClient> _resultFactory;

        #endregion

        #region properties

        private int _position = 0;
        protected virtual int Position
        {
            get
            {
                if (_position >= _data.Count())
                {
                    _position = _data.Count() - 1;
                }

                return _position;
            }
            set
            {
                _position = value;
            }
        }

        #endregion

        #region ctor/init

        protected MockDataFeed(
            string sourceDirectory,
            IResultFactory<INascarApiClient> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            if (!Directory.Exists(sourceDirectory) || Directory.GetFiles(sourceDirectory).Count() == 0)
            {
                var defaultItem = GetDefault();
                _data.Add(defaultItem);
            }
            else
            {
                var directoryInfo = new DirectoryInfo(sourceDirectory);

                var fileList = directoryInfo.GetFiles().OrderBy(f => f.CreationTime);

                foreach (var fileInfo in fileList)
                {
                    var json = File.ReadAllText(fileInfo.FullName);
                    var liveFeedData = JsonConvert.DeserializeObject<T>(json);
                    _data.Add(liveFeedData);
                }
            }
        }

        #endregion

        #region public

        public virtual async Task<IResult<T>> GetDataAsync()
        {
            return await Task.FromResult(_resultFactory.Success(_data[Position++]));
        }

        #endregion

        #region protected

        protected abstract T GetDefault();

        #endregion
    }
}
