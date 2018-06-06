using System.Collections.Generic;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class SubsiteRepository : NHUpdateEntityRepository<SubsiteData>, ISubsiteRepository
    {
        public IEnumerable<SubsiteBriefData> GetSubsites(bool isPublished = false)
        {
            IEnumerable<SubsiteBriefData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<SubsiteBriefData>();
                if (isPublished)
                {
                    query.AddExpressionEq<SubsiteBriefData, bool>(o => o.IsPublished, true);
                }
                result = query.List<SubsiteBriefData>();
            });

            return result;
        }

        public SubsiteInfoData GetSubsiteInfo(object instanceId)
        {
            SubsiteInfoData result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<SubsiteInfoData>();
                query.AddExpressionEq<SubsiteInfoData, object>(o => o.Id, instanceId);
                result = query.UniqueResult<SubsiteInfoData>();
            });

            return result;
        }
    }
}
