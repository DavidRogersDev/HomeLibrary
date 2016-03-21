using System;
using Ninject.Extensions.Interception;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class TransactionAspectInterceptor : IInterceptor
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public TransactionAspectInterceptor(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _unitOfWork.SaveChanges();
                invocation.Proceed();
            }
            catch(Exception exception)
            {
                
            }
        }
    }
}
