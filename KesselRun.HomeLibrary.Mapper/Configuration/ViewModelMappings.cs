using AutoMapper;
using KesselRun.HomeLibrary.Mapper.Configuration.Initializers;

namespace KesselRun.HomeLibrary.Mapper.Configuration
{
    public class ViewModelMappings : MappingBase, IMappingInitializer
    {
        public ViewModelMappings(Profile profile)
            : base(profile)
        {
                
        }

        public void Initialize()
        {
            //  Initialize all individual mappings here
            new BookCoverInitializer(Profile).Initialize();
            new CommentInitializer(Profile).Initialize();
            new PublisherInitializer(Profile).Initialize();
            new BookInitializer(Profile).Initialize();
            new LendingInitializer(Profile).Initialize();
            new PersonInitializer(Profile).Initialize();
        }
    }
}
