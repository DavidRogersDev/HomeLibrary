using System;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.Service.Converters
{
    public class LendingsConverters
    {
        public Expression<Func<Lending, string>> StringToPersonProperty(string column)
        {
            switch (column)
            {
                case "Title":
                    return l => l.Book.Title;
                case "Email":
                    return l => l.Borrower.Email;
            }

            return null;
        }
    }
}
