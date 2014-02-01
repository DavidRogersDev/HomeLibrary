using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiLogic.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsAuthor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sobriquet { get; set; }

        public virtual BindingList<Lending> Lendings { get; set; }
        public virtual BindingList<Book> Books { get; set; }
    }
}
