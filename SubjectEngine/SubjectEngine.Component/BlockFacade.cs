using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class BlockFacade : BusinessComponent
    {
        public BlockFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            BlockSystem = new BlockSystem(unitOfWork);
        }

        private BlockSystem BlockSystem { get; set; }

        public List<TDto> GetBlocksInfo<TDto>(IDataConverter<BlockInfoData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = BlockSystem.GetBlocksInfo(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto GetBlockInfo<TDto>(object instanceId, IDataConverter<BlockInfoData, TDto> converter)
            where TDto : class
        {
            return BlockSystem.GetBlockInfo(instanceId, converter);
        }

        public List<TDto> RetrieveAllBlock<TDto>(IDataConverter<BlockData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = BlockSystem.RetrieveAllBlock(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveOrNewBlock<TDto>(object instanceId, IDataConverter<BlockData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = BlockSystem.RetrieveOrNewBlock(instanceId, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public IFacadeUpdateResult<BlockData> SaveBlock(BlockData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<BlockData> result = BlockSystem.SaveBlock(dto);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }

            return result;
        }

        public IFacadeUpdateResult<BlockData> DeleteBlock(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<BlockData> result = BlockSystem.DeleteBlock(id);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }

            return result;
        }

        public IList<BindingListItem> GetBindingList()
        {
            return BlockSystem.GetBindingList();
        }
    }
}
