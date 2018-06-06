using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IBlockRepository : IUpdateEntityRepository<BlockData>
    {
        IEnumerable<BlockInfoData> GetBlocksInfo();
        BlockInfoData GetBlockInfo(object instanceId);
    }
}
