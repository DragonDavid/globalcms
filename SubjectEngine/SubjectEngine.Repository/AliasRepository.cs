using System.Collections.Generic;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;

namespace SubjectEngine.Repository
{
    public class AliasRepository : NHReadEntityRepository<AliasInfoData>, IAliasRepository
    {
        public IEnumerable<AliasInfoData> GetAliases()
        {
            IEnumerable<AliasInfoData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<AliasInfoData>();
                result = query.List<AliasInfoData>();
            });

            return result;
        }

        public AliasInfoData GetAliasInfo(string alias)
        {
            AliasInfoData result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<AliasInfoData>();
                query.AddExpressionEq<AliasInfoData, string>(o => o.UrlAlias, alias);
                result = query.UniqueResult<AliasInfoData>();
            });

            return result;
        }
    }
}

