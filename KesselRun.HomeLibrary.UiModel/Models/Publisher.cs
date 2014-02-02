using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual BindingList<Book> Books { get; set; }
    }
}
