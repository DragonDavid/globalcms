using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface IAliasService : IReadEntityService<AliasInfoData>
    {
        IServiceQueryResultList<AliasInfoData> GetAliases();
        IServiceQueryResult<AliasInfoData> GetAliasInfo(string alias);
    }
}
