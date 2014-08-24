
namespace KesselRun.HomeLibrary.Ui.CustomControls.EventArgs
{
    public class PagedEventArgs : System.EventArgs
    {
        public readonly int NewPageIndex;
        public readonly int OldPageIndex;
        public readonly string EventRaised;

        public PagedEventArgs(int oldPageIndex, int newPageIndex, string eventRaised)
        {
            EventRaised = eventRaised;
            NewPageIndex = newPageIndex;
            OldPageIndex = oldPageIndex;
        }
    }
}
