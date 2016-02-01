using System.Diagnostics;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class BookHandlers : IQueryHandler<GetBooksSorted, IList<Book>>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUniversalMapper _mapper;
        private bool _disposed = false;

        public BookHandlers(IUnitOfWorkAsync unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IList<Book> Handle(GetBooksSorted query)
        {
            return (from book in _unitOfWork.Repository<Model.Book>()
                        .Query()
                        //.Include(b => b.Authors)
                        //.Include(b => b.Lendings)
                        .Select()
                    let uiBook = new Book()
                    select _mapper.Map(book, uiBook)).ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //_unitOfWork.Dispose();
                _mapper.Dispose();
            }

            _disposed = true;
        }
    }
}
