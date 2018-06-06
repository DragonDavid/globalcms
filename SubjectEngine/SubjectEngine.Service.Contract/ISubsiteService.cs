using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Service.Contract
{
    public interface ISubsiteService : IUpdateEntityService<SubsiteData>
    {
        IServiceQueryResultList<SubsiteBriefData> GetSubsites(bool isPublished = false);
        IServiceQueryResult<SubsiteInfoData> GetSubsiteInfo(object instanceId);
    }
}
