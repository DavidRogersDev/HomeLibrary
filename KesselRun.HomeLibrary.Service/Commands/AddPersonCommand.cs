
namespace KesselRun.HomeLibrary.Service.Commands
{
    public class AddPersonCommand
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public bool IsAuthor { get; set; }
        public string LastName { get; set; }
        public string Sobriquet { get; set; }
    }
}
