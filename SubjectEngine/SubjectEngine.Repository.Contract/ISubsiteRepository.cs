using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface ISubsiteRepository : IUpdateEntityRepository<SubsiteData>
    {
        IEnumerable<SubsiteBriefData> GetSubsites(bool isPublished = false);
        SubsiteInfoData GetSubsiteInfo(object instanceId);
    }
}
