using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using Framework.Data.NHibernate;
using System.Collections.Generic;
using Framework.Data;
using NHibernate;

namespace SubjectEngine.Repository
{
    public class LocationRepository : NHUpdateEntityRepository<LocationData>, ILocationRepository
    {
        public IEnumerable<LocationData> GetPublishedLocations()
        {
            IEnumerable<LocationData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<LocationData>();
                query.AddExpressionEq<LocationData, bool>(o => o.IsPublished, true);
                result = query.List<LocationData>();
            });

            return result;
        }
    }
}
