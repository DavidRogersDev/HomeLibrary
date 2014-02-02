using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class CommentInitializer : MappingBase, IMappingInitializer
    {
        public CommentInitializer(Profile profile)
            : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Comment, UiModel.Models.Comment>();
        }
    }
}
