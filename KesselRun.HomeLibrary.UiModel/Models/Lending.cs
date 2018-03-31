using System;
using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class Lending : IMapFrom<Model.Lending>
    {
        public int Id { get; set; }
        
        public DateTime DateLent { get; set; }
        public DateTime? DueDate { get; set; }
        public int Duration { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Title { get; set; }
    }
}
