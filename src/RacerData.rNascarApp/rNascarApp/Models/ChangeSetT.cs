using System.Collections.Generic;

namespace RacerData.rNascarApp.Models
{
    public class ChangeSet<T>
    {
        public List<T> Added { get; set; }
        public List<T> Edited { get; set; }
        public List<T> Deleted { get; set; }

        public bool HasChanges
        {
            get
            {
                return Added.Count != 0 ||
                    Edited.Count != 0 ||
                    Deleted.Count != 0;
            }
        }

        public ChangeSet()
        {
            Added = new List<T>();
            Edited = new List<T>();
            Deleted = new List<T>();
        }
    }
}
