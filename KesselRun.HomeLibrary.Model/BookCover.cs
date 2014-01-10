using System;

namespace KesselRun.HomeLibrary.Model
{
    public class BookCover
    {
        public Guid BookId { get; set; }
        public byte[] Cover { get; set; }

        public Book Book { get; set; }
    }
}
