using System;
using Ninject.Extensions.Interception;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.ObjectResolution
{
    public class TransactionAspectInterceptor : SimpleInterceptor
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public TransactionAspectInterceptor(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            try
            {
                _unitOfWork.SaveChanges();
                //invocation.Proceed();
            }
            catch (Exception exception)
            {

            }
        }
    }
}
