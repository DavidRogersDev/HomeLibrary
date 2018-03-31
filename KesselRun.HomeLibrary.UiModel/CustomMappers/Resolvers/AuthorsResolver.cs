using System.Linq;
using System.Text;
using AutoMapper;

namespace KesselRun.HomeLibrary.UiModel.CustomMappers.Resolvers
{
    public class AuthorsResolver<D, M> : IValueResolver<D, M, string>
        where D : Model.Lending
    {
        #region Overrides of ValueResolver<List<Task>,List<Task>>

        public string Resolve(D source, M destination, string destMember, ResolutionContext context)
        {
            var stringBuilder = new StringBuilder();
            var authors = source.Book.Authors.Select(a => a.FirstName + " " + a.LastName).ToList();
            int authorCount = authors.Count;

            for (int i = 0; i < authorCount; i++)
            {
                if (i < authorCount - 1)
                {
                    stringBuilder.Append(authors[i] + ", ");
                }
                else
                {
                    stringBuilder.Append(authors[i]);
                }
            }

            return stringBuilder.ToString();
        }

        #endregion

    }
}
