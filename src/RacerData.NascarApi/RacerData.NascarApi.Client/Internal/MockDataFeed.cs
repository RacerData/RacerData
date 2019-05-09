using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockDataFeed<T>
    {
        #region fields

        private readonly IList<T> _data = new List<T>();
        private readonly IResultFactory<INascarApiClient> _resultFactory;

        #endregion

        #region properties

        private int _position = 0;
        protected int Position
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
            var directoryInfo = new DirectoryInfo(sourceDirectory);

            foreach (var fileInfo in directoryInfo.GetFiles().OrderBy(f => f.CreationTime))
            {
                var json = File.ReadAllText(fileInfo.FullName);
                var liveFeedData = JsonConvert.DeserializeObject<T>(json);
                _data.Add(liveFeedData);
            }
        }

        #endregion

        #region public

        public virtual async Task<IResult<T>> GetDataAsync()
        {
            return await Task.FromResult(_resultFactory.Success(_data[Position++]));
        }

        #endregion
    }
}
