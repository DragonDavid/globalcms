using System.Collections.Generic;
using SubjectEngine.Data;
using Framework.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IAliasRepository : IReadEntityRepository<AliasInfoData>
    {
        IEnumerable<AliasInfoData> GetAliases();
        AliasInfoData GetAliasInfo(string alias);
    }
}
