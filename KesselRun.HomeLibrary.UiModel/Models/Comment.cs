namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public string CommentText { get; set; }
    }
}
