using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class LocationService : UpdateEntityService<ILocationRepository, LocationData>, ILocationService
    {
        public IServiceQueryResultList<LocationData> GetPublishedLocations()
        {
            IEnumerable<LocationData> result = Repository.GetPublishedLocations();
            return ServiceResultFactory.BuildServiceQueryResult<LocationData>(result);
        }
    }
}
