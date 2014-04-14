using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service
{
    public class LendingsService : ILendingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public LendingsService(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }


        public IList<Lending> GetLendings()
        {
            IList<Lending> lendings = new List<Lending>();

            foreach (var lending in _unitOfWork.Lendings.GetAllIncluding(l => l.Book.Authors, l => l.Borrower))
            {
                var newLending = new Lending();
                 lendings.Add(_mapper.Map(lending, newLending));
            }
            return lendings;
        }
    }
}
