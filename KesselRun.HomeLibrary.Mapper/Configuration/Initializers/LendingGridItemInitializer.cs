using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class LendingGridItemInitializer : MappingBase, IMappingInitializer
    {
        public LendingGridItemInitializer(Profile profile)
            : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Lending, UiModel.Models.LendingGridItem>()
                .ForMember(viewType => viewType.Authors, domainType => domainType.ResolveUsing<AuthorsResolver>().FromMember(src => src.Book.Authors.Select(a => a.FirstName + " " + a.LastName).ToList()))
                .ForMember(viewType => viewType.Borrower, domainType => domainType.MapFrom(d => d.Borrower.FirstName))
                .ForMember(viewType => viewType.Email, domainType => domainType.MapFrom(d => d.Borrower.Email))
                .ForMember(viewType => viewType.Title, domainType => domainType.MapFrom(d => d.Book.Title))
                .ForMember(viewType => viewType.Duration, domainType => domainType.MapFrom(d => Math.Abs(d.DateLent.Subtract(DateTime.Now).Days))
                );
        }

        public class AuthorsResolver : ValueResolver<IList<string>, string>
        {
            #region Overrides of ValueResolver<List<Task>,List<Task>>

            protected override string ResolveCore(IList<string> source)
            {
                var stringBuilder = new StringBuilder();
                int authorCount = source.Count;

                for (int i = 0; i < authorCount; i++)
                {
                    if (i < authorCount - 1)
                    {
                        stringBuilder.Append(source[i] + ", ");
                    }
                    else
                    {
                        stringBuilder.Append(source[i]);
                    }
                }

                return stringBuilder.ToString();
            }

            #endregion

        }
    }
}
