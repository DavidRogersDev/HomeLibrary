using System;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories.Contracts;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Repositories
{
    public class LendingRepository : RepositoryBase<Lending, HomeLibraryContext>, ILendingRepository
    {
        public LendingRepository()
        {

        }

        public LendingRepository(HomeLibraryContext ctx)
            : base(ctx)
        {

        }

        public override void CheckDisposed()
        {
            if (Context == null)
            {
                throw new ObjectDisposedException("LendingRepository");
            }
        }
    }
}
