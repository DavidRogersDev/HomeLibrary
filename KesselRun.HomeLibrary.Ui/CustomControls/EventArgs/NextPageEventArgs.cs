
namespace KesselRun.HomeLibrary.Ui.CustomControls.EventArgs
{
    public class NextPageEventArgs : System.EventArgs
    {
        public readonly int NewPageIndex;
        public readonly int OldPageIndex;

        public NextPageEventArgs(int oldPageIndex, int newPageIndex)
        {
            NewPageIndex = newPageIndex;
            OldPageIndex = oldPageIndex;
        }
    }
}
