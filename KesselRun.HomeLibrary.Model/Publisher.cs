using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;

namespace KesselRun.HomeLibrary.Model
{
    public class Publisher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}