using System.Collections.Generic;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service
{
    public class BlockService : UpdateEntityService<IBlockRepository, BlockData>, IBlockService
    {
        public IServiceQueryResultList<BlockInfoData> GetBlocksInfo()
        {
            IEnumerable<BlockInfoData> result = Repository.GetBlocksInfo();
            return ServiceResultFactory.BuildServiceQueryResult<BlockInfoData>(result);
        }

        public IServiceQueryResult<BlockInfoData> GetBlockInfo(object instanceId)
        {
            BlockInfoData result = Repository.GetBlockInfo(instanceId);
            return ServiceResultFactory.BuildServiceQueryResult<BlockInfoData>(result);
        }
    }
}
