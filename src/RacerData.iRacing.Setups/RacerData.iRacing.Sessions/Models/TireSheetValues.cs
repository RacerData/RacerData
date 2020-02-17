using System.Collections.Generic;

namespace RacerData.iRacing.Sessions.Models
{
    public class TireSheetValues
    {
        public float ColdPsi { get; set; }
        public float HotPsi { get; set; }
        public IDictionary<TreadPosition, float> Wear { get; set; }
        public IDictionary<TreadPosition, float> Temperatures { get; set; }

        public TireSheetValues()
        {
            Wear = BuildValueDictionary();
            Temperatures = BuildValueDictionary();
        }

        protected virtual IDictionary<TreadPosition, float> BuildValueDictionary()
        {
            var valueDictionary = new Dictionary<TreadPosition, float>();

            valueDictionary.Add(TreadPosition.Inside, 0);
            valueDictionary.Add(TreadPosition.Middle, 0);
            valueDictionary.Add(TreadPosition.Outside, 0);

            return valueDictionary;
        }
    }
}
