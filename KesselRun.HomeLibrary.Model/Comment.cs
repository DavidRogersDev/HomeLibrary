using KesselRun.HomeLibrary.GenericRepository;

namespace KesselRun.HomeLibrary.Model
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string CommentText { get; set; }
    }
}
