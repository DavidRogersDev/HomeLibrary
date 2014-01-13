using System;

namespace KesselRun.HomeLibrary.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public Guid BookId { get; set; }
        public string CommentText { get; set; }
    }
}
