using System.Collections.Generic;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Repositories.Contracts
{
    public interface ILendingRepository<TLending>
        where TLending : Lending
    {
        TLending Create();
        void Add(TLending item);
        void Remove(TLending item);
        void Update(TLending item);
        TLending GetById(int id);
        IList<TLending> GetAll();
    }

    public interface ILendingRepository : ILendingRepository<Lending>
    {
        
    }
}
