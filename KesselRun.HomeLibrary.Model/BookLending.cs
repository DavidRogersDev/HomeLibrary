using System;

namespace KesselRun.HomeLibrary.Model
{
    public class BookLending
    {
        public Guid BookId { get; set; }
        public Guid LendingId { get; set; }
        public DateTime ReturnDate { get; set; }

        public Guid Book{ get; set; }
        public Guid Lending { get; set; }
    }
}
