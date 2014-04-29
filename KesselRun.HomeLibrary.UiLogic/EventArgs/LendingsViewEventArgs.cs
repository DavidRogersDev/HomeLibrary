
namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class LendingsViewEventArgs : System.EventArgs
    {
        public readonly int PageSize;
        public readonly int PageIndex;

        public LendingsViewEventArgs(int pageSize, int pageIndex)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }
    }
}
