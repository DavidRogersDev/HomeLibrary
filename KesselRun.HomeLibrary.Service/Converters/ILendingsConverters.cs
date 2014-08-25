using System;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Enums;

namespace KesselRun.HomeLibrary.Service.Converters
{
    public interface ILendingsConverters
    {
        Expression<Func<Lending, bool>> FilterToFuncProperty(string filterString, FilterType filterType);
        Expression<Func<Lending, DateTime?>> StringToDateTimeProperty(string column);
        Expression<Func<Lending, string>> StringToStringProperty(string column);
    }
}