using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration
{
    public abstract class MappingBase
    {
        private readonly Profile _profile;

        protected MappingBase(Profile profile)
        {
            _profile = profile;
            SetNamingConventions();
        }

        private void SetNamingConventions()
        {
            Profile.SourceMemberNamingConvention = new PascalCaseNamingConvention();
            Profile.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }

        public Profile Profile
        {
            get { return _profile; }
        }
    }
}
