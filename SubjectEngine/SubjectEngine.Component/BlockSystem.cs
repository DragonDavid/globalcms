using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Business;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class BlockSystem : BusinessComponent
    {
        public BlockSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> GetBlocksInfo<TDto>(IDataConverter<BlockInfoData, TDto> converter)
            where TDto : class
        {
            IBlockService service = UnitOfWork.GetService<IBlockService>();
            var query = service.GetBlocksInfo();
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto GetBlockInfo<TDto>(object instanceId, IDataConverter<BlockInfoData, TDto> converter)
            where TDto : class
        {
            IBlockService service = UnitOfWork.GetService<IBlockService>();
            var query = service.GetBlockInfo(instanceId);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }

            return null;
        }

        internal List<TDto> RetrieveAllBlock<TDto>(IDataConverter<BlockData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IBlockService service = UnitOfWork.GetService<IBlockService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveOrNewBlock<TDto>(object instanceId, IDataConverter<BlockData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IBlockService service = UnitOfWork.GetService<IBlockService>();
            FacadeUpdateResult<BlockData> result = new FacadeUpdateResult<BlockData>();
            Block instance = RetrieveOrNew<BlockData, Block, IBlockService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<BlockData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<BlockData> SaveBlock(BlockData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<BlockData> result = new FacadeUpdateResult<BlockData>();
            IBlockService service = UnitOfWork.GetService<IBlockService>();
            Block instance = RetrieveOrNew<BlockData, Block, IBlockService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.Description = dto.Description;
                instance.IsBuiltIn = dto.IsBuiltIn;
                instance.WidgetName = dto.WidgetName;
                instance.ModifiedDate = DateTime.Now;
                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<BlockData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<BlockData> DeleteBlock(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<BlockData> result = new FacadeUpdateResult<BlockData>();
            IBlockService service = UnitOfWork.GetService<IBlockService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Block instance = query.ToBo<Block>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "BlockCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            IBlockService service = UnitOfWork.GetService<IBlockService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (BlockData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
