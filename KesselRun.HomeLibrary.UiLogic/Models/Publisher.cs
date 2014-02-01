using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiLogic.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual BindingList<Book> Books { get; set; }
    }
}
