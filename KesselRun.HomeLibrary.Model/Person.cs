using System;
using System.Collections.Generic;

namespace KesselRun.HomeLibrary.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsAuthor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sobriquet { get; set; }

        public virtual ICollection<Lending> Lendings { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
