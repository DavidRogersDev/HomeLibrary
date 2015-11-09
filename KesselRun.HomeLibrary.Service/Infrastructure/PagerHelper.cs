using KesselRun.HomeLibrary.UiModel;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public class PagerHelper
    {
        public static void ProcessPagingData(IPageCapbable query, PagerData pagerData, int totalSize)
        {
            var remainder = ResolvePageIndex(query, totalSize);

            PopulateNumberOfPages(query, pagerData, totalSize, remainder);

            PopulateOtherPagerInfo(query, pagerData);
        }

        private static int ResolvePageIndex(IPageCapbable query, int totalSize)
        {
            var pageCount = totalSize/query.PageSize;
            var remainder = totalSize%query.PageSize;

            if (query.PageIndex > pageCount)
            {
                if (remainder > 0)
                {
                    if (remainder <= totalSize)
                    {
                        query.PageIndex = ++pageCount;
                    }
                }
                else if (remainder == 0)
                {
                    query.PageIndex = pageCount;
                }
            }
            return remainder;
        }

        private static void PopulateNumberOfPages(IPageCapbable query, PagerData pagerData, int totalSize, int remainder)
        {
            if (query.PageSize == 1 || remainder == 0)
                pagerData.NumberOfPages = totalSize/query.PageSize;
            else
                pagerData.NumberOfPages = (totalSize/query.PageSize) + 1;
        }

        private static void PopulateOtherPagerInfo(IPageCapbable query, PagerData pagerData)
        {
            pagerData.PageNumber = query.PageIndex;
            pagerData.PageSize = query.PageSize;
            pagerData.SortByField = query.SortBy;
            pagerData.SortOrder = query.OrderByDirection;
        }
    }
}
