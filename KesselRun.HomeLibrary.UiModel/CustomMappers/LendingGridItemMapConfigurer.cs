using System;
using AutoMapper;
using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;
using KesselRun.HomeLibrary.UiModel.CustomMappers.Resolvers;

namespace KesselRun.HomeLibrary.UiModel.CustomMappers
{
    public class LendingGridItemMapConfigurer : IHaveCustomMappings
    {
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Model.Lending, Models.LendingGridItem>()
                .ForMember(viewType => viewType.Authors, domainType => domainType.ResolveUsing<AuthorsResolver<Model.Lending, Models.LendingGridItem>>())
                .ForMember(viewType => viewType.Borrower, domainType => domainType.MapFrom(d => d.Borrower.FirstName))
                .ForMember(viewType => viewType.Email, domainType => domainType.MapFrom(d => d.Borrower.Email))
                .ForMember(viewType => viewType.Title, domainType => domainType.MapFrom(d => d.Book.Title))
                .ForMember(viewType => viewType.Duration, domainType => domainType.MapFrom(d => Math.Abs(d.DateLent.Subtract(DateTime.Now).Days))
            );
        }
    }
}
