using System;
using log4net;
using RacerData.Commmon.Results;
using RacerData.Common.Ports;
using RacerData.Data.Json.Models;
using RacerData.Data.Json.Ports;
using RacerData.Data.Ports;

namespace RacerData.Data.Json.Adapters
{
    class TestJsonRepository : JsonRepository<TestItem, Guid>, IJsonRepository<TestItem, Guid>
    {
        #region ctor

        public TestJsonRepository(
           ILog log,
           IDirectoryService directoryService,
           ISerializer serializer,
           IRevertableService revertableService,
           IResultFactory<JsonRepository<TestItem, Guid>> resultFactory)
            : base(log, directoryService, serializer, revertableService, resultFactory)
        {
        }

        #endregion
    }
}

namespace RacerData.Data.Json.Models
{
    public class TestItem : IKeyedItem<Guid>
    {
        public Guid Key { get => Id; set => Id = value; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

