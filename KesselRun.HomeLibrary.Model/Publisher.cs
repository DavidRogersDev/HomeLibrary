using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model
{
    public class Publisher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public State State { get; set; }
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}