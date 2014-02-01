namespace KesselRun.HomeLibrary.Mapper.Mappers
{
    public interface IUniversalMapper
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
