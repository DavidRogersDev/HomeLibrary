using System;
using System.ComponentModel.DataAnnotations;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class Lending
    {
        public int Id { get; set; }
        public string Authors { get; set; }
        public string Borrower { get; set; }
        public DateTime DateLent { get; set; }
        public DateTime? DueDate { get; set; }
        public int Duration { get; set; }
        public string Email { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Title { get; set; }
    }
}
