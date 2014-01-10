using System;

namespace KesselRun.HomeLibrary.Model
{
    public class Comment
    {
        public Guid BookId { get; set; }
        public string CommentText { get; set; }
    }
}
