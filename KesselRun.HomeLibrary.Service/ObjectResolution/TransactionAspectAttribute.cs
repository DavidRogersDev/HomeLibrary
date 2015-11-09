using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace KesselRun.HomeLibrary.Service.ObjectResolution
{
    public class TransactionAspectAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Kernel.Get<TransactionAspectInterceptor>();
        }
    }
}
