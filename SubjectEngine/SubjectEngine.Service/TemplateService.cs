using System.Collections.Generic;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service
{
    public class TemplateService : UpdateEntityService<ITemplateRepository, TemplateData>, ITemplateService
    {
        public IServiceQueryResultList<TemplateInfoData> GetTemplatesInfo()
        {
            IEnumerable<TemplateInfoData> result = Repository.GetTemplatesInfo();
            return ServiceResultFactory.BuildServiceQueryResult<TemplateInfoData>(result);
        }

        public IServiceQueryResult<TemplateInfoData> GetTemplateInfo(object instanceId)
        {
            TemplateInfoData result = Repository.GetTemplateInfo(instanceId);
            return ServiceResultFactory.BuildServiceQueryResult<TemplateInfoData>(result);
        }
    }
}
