using System;
using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model.Contracts;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model
{
    public class Lending : IEntity, IObjectWithState
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Person Borrower { get; set; }
        public int BorrowerId { get; set; }
        public DateTime DateLent { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public State State { get; set; }
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
