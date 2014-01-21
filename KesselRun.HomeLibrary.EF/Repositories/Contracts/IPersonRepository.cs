using System.Collections.Generic;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Repositories.Contracts
{
    public interface IPersonRepository<TPerson>
        where TPerson : Person
    {
        TPerson Create();
        void Add(TPerson item);
        void Remove(TPerson item);
        void Update(TPerson item);
        TPerson GetById(int id);
        IList<TPerson> GetAll();
    }

    public interface IPersonRepository : IPersonRepository<Person>{ }
}
