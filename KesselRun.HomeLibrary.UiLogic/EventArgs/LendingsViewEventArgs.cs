
namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class LendingsViewEventArgs : System.EventArgs
    {
        public readonly int PageSize;
        public readonly int PageIndex;
        public readonly string SortBy;

        public LendingsViewEventArgs(int pageSize, int pageIndex, string sortBy)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            SortBy = sortBy;
        }
    }
}
