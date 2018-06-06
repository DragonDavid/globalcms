using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface ITemplateRepository : IUpdateEntityRepository<TemplateData>
    {
        IEnumerable<TemplateInfoData> GetTemplatesInfo();
        TemplateInfoData GetTemplateInfo(object instanceId);
    }
}
