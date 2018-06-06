using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface ILocationService : IUpdateEntityService<LocationData>
    {
        IServiceQueryResultList<LocationData> GetPublishedLocations();
    }
}
