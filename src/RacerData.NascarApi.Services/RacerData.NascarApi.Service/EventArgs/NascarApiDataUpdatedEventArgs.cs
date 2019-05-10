using System;

namespace RacerData.NascarApi.Service
{
    public class NascarApiDataUpdatedEventArgs<T> : EventArgs
    {
        public ApiFeedType ApiFeedType { get; set; }
        public T Data { get; set; }
    }
}
