using KesselRun.HomeLibrary.UiLogic.Enums;

namespace KesselRun.HomeLibrary.UiLogic.Models
{
    public class BookCover
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Edition Edition { get; set; }
        public byte[] Cover { get; set; }
    }
}
