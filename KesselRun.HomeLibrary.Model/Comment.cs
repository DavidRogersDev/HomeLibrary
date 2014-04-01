using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model.Contracts;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model
{
    public class Comment : IEntity, IObjectWithState
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string CommentText { get; set; }
        public State State { get; set; }
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
