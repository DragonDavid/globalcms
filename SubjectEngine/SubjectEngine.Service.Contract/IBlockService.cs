using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface IBlockService : IUpdateEntityService<BlockData>
    {
        IServiceQueryResultList<BlockInfoData> GetBlocksInfo();
        IServiceQueryResult<BlockInfoData> GetBlockInfo(object instanceId);
    }
}
