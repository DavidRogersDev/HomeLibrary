using System;
using KesselRun.HomeLibrary.GenericRepository;

namespace KesselRun.HomeLibrary.Model
{
    public class Lending : IEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Person Borrower { get; set; }
        public int BorrowerId { get; set; }
        public DateTime DateLent { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
