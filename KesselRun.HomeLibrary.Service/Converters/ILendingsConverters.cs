using System;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.Service.Converters
{
    public interface ILendingsConverters
    {
        Expression<Func<Lending, DateTime?>> StringToDateTimeProperty(string column);
        Expression<Func<Lending, string>> StringToStringProperty(string column);
    }
}