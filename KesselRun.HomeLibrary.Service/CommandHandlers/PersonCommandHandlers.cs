using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.CommandHandlers
{
    public class PersonCommandHandlers : ICommandHandler<AddPersonCommand>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        public PersonCommandHandlers(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(AddPersonCommand command)
        {
            _unitOfWork.Repository<Person>().Insert(new Person
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsAuthor = command.IsAuthor,
                Sobriquet = command.Sobriquet,
            });

            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
