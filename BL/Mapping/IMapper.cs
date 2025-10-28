namespace BL.Mapping
{
    public interface IMapper
    {
        public TDestination Map<TSource, TDestination>();
    }
}
