using System.ComponentModel;
using KesselRun.HomeLibrary.UiLogic.Enums;

namespace KesselRun.HomeLibrary.UiLogic.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Edition Edition { get; set; }
        public Publisher Publisher { get; set; }
        public BookType TypeOfBook { get; set; }

        public virtual BindingList<Person> Authors { get; set; }
        public virtual BindingList<Comment> Comments { get; set; }
        public virtual BindingList<BookCover> Covers { get; set; }
        public virtual BindingList<Lending> Lendings { get; set; }
    }
}
