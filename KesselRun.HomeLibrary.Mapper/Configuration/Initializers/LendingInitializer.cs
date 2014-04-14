using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class LendingInitializer : MappingBase, IMappingInitializer
    {
        public LendingInitializer(Profile profile) : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Lending, UiModel.Models.Lending>()
                .ForMember(viewType => viewType.Authors, domainType => domainType.ResolveUsing<AuthorsResolver>().FromMember(src => src.Book.Authors.Select(a => a.FirstName + " " + a.LastName).ToList()))
                .ForMember(viewType => viewType.Borrower, domainType => domainType.MapFrom(d => d.Borrower.FirstName))
                .ForMember(viewType => viewType.DateLent, domainType => domainType.MapFrom(d => d.DateLent))
                .ForMember(viewType => viewType.DueDate, domainType => domainType.MapFrom(d => d.DueDate))
                .ForMember(viewType => viewType.ReturnDate, domainType => domainType.MapFrom(d => d.ReturnDate))
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

                foreach (var author in source)
                {
                    stringBuilder.Append(author + ", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2);

                return stringBuilder.ToString();
            }

            #endregion

        }
    }
}
