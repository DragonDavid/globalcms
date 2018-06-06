using System.Collections.Generic;
using Framework.Core;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class TemplateRepository : NHUpdateEntityRepository<TemplateData>, ITemplateRepository
    {
        public IEnumerable<TemplateInfoData> GetTemplatesInfo()
        {
            IEnumerable<TemplateInfoData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<TemplateInfoData>();
                result = query.List<TemplateInfoData>();
            });

            return result;
        }

        public TemplateInfoData GetTemplateInfo(object instanceId)
        {
            TemplateInfoData result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<TemplateInfoData>();
                query.AddExpressionEq<TemplateInfoData, object>(o => o.Id, instanceId);
                result = query.UniqueResult<TemplateInfoData>();
            });

            return result;
        }
    }
}
