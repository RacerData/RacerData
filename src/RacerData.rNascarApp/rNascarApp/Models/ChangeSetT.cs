using System.Collections.Generic;

namespace RacerData.rNascarApp.Models
{
    public class ChangeSet<T>
   {
        public List<T> Added { get; set; }
        public List<T> Edited { get; set; }
        public List<T> Deleted { get; set; }

        public ChangeSet()
        {
            Added = new List<T>();
            Edited = new List<T>();
            Deleted = new List<T>();
        }
    }
}
