using System;

namespace KesselRun.HomeLibrary.Model
{
    public class Lending
    {
        public Guid Id { get; set; }
        public Guid BorrowerId { get; set; }
        public Person Borrower { get; set; }
        public DateTime DateLent { get; set; }
    }
}
