using System.Collections.Generic;
using Framework.Core;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class BlockRepository : NHUpdateEntityRepository<BlockData>, IBlockRepository
    {
        public IEnumerable<BlockInfoData> GetBlocksInfo()
        {
            IEnumerable<BlockInfoData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<BlockInfoData>();
                result = query.List<BlockInfoData>();
            });

            return result;
        }

        public BlockInfoData GetBlockInfo(object instanceId)
        {
            BlockInfoData result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<BlockInfoData>();
                query.AddExpressionEq<BlockInfoData, object>(o => o.Id, instanceId);
                result = query.UniqueResult<BlockInfoData>();
            });

            return result;
        }
    }
}
