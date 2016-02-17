namespace TwitSystem.Web.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}
