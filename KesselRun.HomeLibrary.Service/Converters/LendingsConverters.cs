using System;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Infrastructure;

namespace KesselRun.HomeLibrary.Service.Converters
{
    public class LendingsConverters : ILendingsConverters
    {
        public Expression<Func<Lending, DateTime?>> StringToDateTimeProperty(string column)
        {
            switch (column)
            {
                case Constants.DateLent:
                    return l => l.DateLent;
                case Constants.DueDate:
                    return l => l.DueDate;
                case Constants.ReturnDate:
                    return l => l.ReturnDate;
            }

            return null;
        }

        public Expression<Func<Lending, string>> StringToStringProperty(string column)
        {
            switch (column)
            {
                case Constants.Borrower:
                    return l => l.Borrower.LastName;
                case Constants.Email:
                    return l => l.Borrower.Email;
                case Constants.Title:
                    return l => l.Book.Title;
            }

            return null;
        }
    }
}
