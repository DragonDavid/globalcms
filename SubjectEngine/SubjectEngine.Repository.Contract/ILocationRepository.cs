using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface ILocationRepository : IUpdateEntityRepository<LocationData>
    {
        IEnumerable<LocationData> GetPublishedLocations();
    }
}
