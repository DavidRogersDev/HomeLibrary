using System.Collections.Generic;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class BookHandlers : IQueryHandler<GetBooksSorted, IList<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public BookHandlers(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IList<Book> Handle(GetBooksSorted query)
        {
            IList<Book> books = new List<Book>();

            foreach (var book in _unitOfWork.Repository<Model.Book>().GetAll())
            {
                var uiBook = new Book();
                books.Add(_mapper.Map(book, uiBook));
            }

            return books;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
