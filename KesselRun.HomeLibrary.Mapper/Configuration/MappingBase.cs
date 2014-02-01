using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration
{
    public abstract class MappingBase
    {
        private readonly Profile _profile;

        protected MappingBase(Profile profile)
        {
            _profile = profile;
            _profile.SourceMemberNamingConvention = new PascalCaseNamingConvention();
            _profile.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }

        public Profile Profile
        {
            get { return _profile; }
        }
    }
}
