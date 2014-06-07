using System.Collections.Generic;
using KesselRun.HomeLibrary.Model.Enums;
using Repository.Pattern.Ef6;

namespace KesselRun.HomeLibrary.Model
{
    public class Comment : Entity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string CommentText { get; set; }
    }
}
