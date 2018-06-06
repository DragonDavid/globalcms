using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface ITemplateService : IUpdateEntityService<TemplateData>
    {
        IServiceQueryResultList<TemplateInfoData> GetTemplatesInfo();
        IServiceQueryResult<TemplateInfoData> GetTemplateInfo(object instanceId);
    }
}
