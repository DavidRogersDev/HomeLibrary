using System.Collections.Generic;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model.Contracts;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model
{
    public class BookCover : IEntity, IObjectWithState
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Edition Edition { get; set; }
        public byte[] Cover { get; set; }
        public State State { get; set; }
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
