using System.Collections.Generic;

namespace RacerData.iRacing.Sessions.Models
{
    public class TireSheet
    {
        public long RunId { get; set; }
        public IDictionary<TirePosition, TireSheetValues> Tires { get; set; }

        public TireSheet()
        {
            Tires = BuildTireDictionaries();
        }

        protected virtual IDictionary<TirePosition, TireSheetValues> BuildTireDictionaries()
        {
            var tireDictionary = new Dictionary<TirePosition, TireSheetValues>();

            tireDictionary.Add(TirePosition.LF, new TireSheetValues());
            tireDictionary.Add(TirePosition.LR, new TireSheetValues());
            tireDictionary.Add(TirePosition.RF, new TireSheetValues());
            tireDictionary.Add(TirePosition.RR, new TireSheetValues());

            return tireDictionary;
        }
    }
}
