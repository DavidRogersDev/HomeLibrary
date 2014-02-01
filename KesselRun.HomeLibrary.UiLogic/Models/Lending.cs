using System;

namespace KesselRun.HomeLibrary.UiLogic.Models
{
    public class Lending
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Person Borrower { get; set; }
        public DateTime DateLent { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
