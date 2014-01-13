using System;

namespace KesselRun.HomeLibrary.Model
{
    public class Lending
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public Guid BookId { get; set; }
        public Person Borrower { get; set; }
        public Guid BorrowerId { get; set; }
        public DateTime DateLent { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
