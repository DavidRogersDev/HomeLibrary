using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsAuthor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sobriquet { get; set; }

        public virtual ICollection<Lending> Lendings { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public State State { get; set; }
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
