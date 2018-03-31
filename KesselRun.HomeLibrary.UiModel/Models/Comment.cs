using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class Comment : IMapFrom<Model.Comment>
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public string CommentText { get; set; }
    }
}
