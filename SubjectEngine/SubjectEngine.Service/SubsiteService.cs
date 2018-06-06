using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class SubsiteService : UpdateEntityService<ISubsiteRepository, SubsiteData>, ISubsiteService
    {
        public IServiceQueryResultList<SubsiteBriefData> GetSubsites(bool isPublished = false)
        {
            IEnumerable<SubsiteBriefData> result = Repository.GetSubsites(isPublished);
            return ServiceResultFactory.BuildServiceQueryResult<SubsiteBriefData>(result);
        }

        public IServiceQueryResult<SubsiteInfoData> GetSubsiteInfo(object instanceId)
        {
            SubsiteInfoData result = Repository.GetSubsiteInfo(instanceId);
            return ServiceResultFactory.BuildServiceQueryResult<SubsiteInfoData>(result);
        }
    }
}
