using System.Collections.Generic;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Repositories.Contracts
{
    public interface IBookRepository<TBook>
        where TBook : Book
    {
        TBook Create();
        void Add(TBook item);
        void Remove(TBook item);
        void Update(TBook item);
        TBook GetById(int id);
        IList<TBook> GetAll();

    }

    public interface IBookRepository : IBookRepository<Book>
    {

    }
}
