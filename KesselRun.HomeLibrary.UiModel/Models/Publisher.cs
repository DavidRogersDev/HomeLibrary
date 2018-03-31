using System.ComponentModel;
using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class Publisher : IMapFrom<Model.Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual BindingList<Book> Books { get; set; }
    }
}
