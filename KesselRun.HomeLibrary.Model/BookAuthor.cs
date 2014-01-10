using System;

namespace KesselRun.HomeLibrary.Model
{
    public class BookAuthor
    {
        public Guid BookId { get; set; }
        public Guid PersonId { get; set; }

        public Book Book { get; set; }
        public Person Author { get; set; }
    }
}