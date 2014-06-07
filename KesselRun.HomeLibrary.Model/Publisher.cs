using System.Collections.Generic;
using KesselRun.HomeLibrary.Model.Enums;
using Repository.Pattern.Ef6;

namespace KesselRun.HomeLibrary.Model
{
    public class Publisher : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}