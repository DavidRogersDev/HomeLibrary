
namespace KesselRun.HomeLibrary.Ui.CustomControls.EventArgs
{
    public class NextPageEventArgs : System.EventArgs
    {
        public readonly int NewPageNumber;
        public readonly int OldPageNumber;

        public NextPageEventArgs(int oldPageNumber, int newPageNumber)
        {
            NewPageNumber = newPageNumber;
            OldPageNumber = oldPageNumber;
        }
    }
}
