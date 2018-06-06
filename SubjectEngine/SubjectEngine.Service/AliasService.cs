using System.Collections.Generic;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service
{
    public class AliasService : ReadEntityService<IAliasRepository, AliasInfoData>, IAliasService
    {
        public IServiceQueryResultList<AliasInfoData> GetAliases()
        {
            IEnumerable<AliasInfoData> result = Repository.GetAliases();
            return ServiceResultFactory.BuildServiceQueryResult<AliasInfoData>(result);
        }

        public IServiceQueryResult<AliasInfoData> GetAliasInfo(string alias)
        {
            AliasInfoData result = Repository.GetAliasInfo(alias);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }
    }
}
