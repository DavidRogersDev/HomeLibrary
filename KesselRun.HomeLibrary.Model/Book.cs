using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Edition Edition { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public BookType TypeOfBook { get; set; }

        public virtual ICollection<Person> Authors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<BookCover> Covers { get; set; }
        public virtual ICollection<Lending> Lendings { get; set; }
        
        public State State { get; set; }
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
