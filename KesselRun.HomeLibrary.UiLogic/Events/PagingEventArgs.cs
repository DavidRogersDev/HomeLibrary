using System;

namespace KesselRun.HomeLibrary.UiLogic.Events
{
    public class PagingEventArgs : EventArgs
    {
        public int PageIndex;
        public int PageSize;
        public int PageCount;

        public PagingEventArgs(int pageIndex, int pageSize, int pageCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = pageCount;
        }
    }
}