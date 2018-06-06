using System.Collections.Generic;
using System.Linq;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using SubjectEngine.Core;
using SubjectEngine.Business;

namespace SubjectEngine.Component
{
    internal class CollectionSystem : BusinessComponent
    {
        public CollectionSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> RetrieveAllCollection<TDto>(IDataConverter<CollectionData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveOrNewCollection<TDto>(object instanceId, IDataConverter<CollectionData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();
            FacadeUpdateResult<CollectionData> result = new FacadeUpdateResult<CollectionData>();
            Collection instance = RetrieveOrNew<CollectionData, Collection, ICollectionService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<CollectionData>());
            }
            else
            {
                return null;
            }
        }

        internal FacadeUpdateResult<CollectionData> SaveCollection(CollectionData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<CollectionData> result = new FacadeUpdateResult<CollectionData>();
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();
            Collection instance = RetrieveOrNew<CollectionData, Collection, ICollectionService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.CreatedById = dto.CreatedById;
                instance.CreatedDate = dto.CreatedDate;
                instance.ModifiedDate = dto.ModifiedDate;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<CollectionData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<CollectionData> SaveCollectionItem(object parentId, CollectionItemData childDto)
        {
            ArgumentValidator.IsNotNull("parentId", parentId);
            ArgumentValidator.IsNotNull("childDto", childDto);

            FacadeUpdateResult<CollectionData> result = new FacadeUpdateResult<CollectionData>();
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();
            Collection instance = RetrieveOrNew<CollectionData, Collection, ICollectionService>(result.ValidationResult, childDto.Id);

            if (result.IsSuccessful)
            {
                CollectionItem collectionItem = RetrieveOrNewCollectionItem(instance, childDto.Id);
                if (collectionItem != null)
                {
                    collectionItem.ReferenceId = childDto.ReferenceId;
                    collectionItem.Sort = childDto.Sort;

                    var saveQuery = service.Save(instance);
                    result.AttachResult(instance.RetrieveData<CollectionData>());
                    result.Merge(saveQuery);
                }
                else
                {
                    AddError(result.ValidationResult, "CollectionItemCannotBeFound");
                }
            }

            return result;
        }

        internal CollectionItem RetrieveOrNewCollectionItem(Collection parent, object childId)
        {
            CollectionItem child = null;

            if (childId != null)
            {
                child = parent.CollectionItems.SingleOrDefault(o => object.Equals(o.Id, childId));
            }
            else
            {
                child = parent.CollectionItems.AddNewBo();
            }

            return child;
        }

        internal IFacadeUpdateResult<CollectionData> DeleteCollection(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<CollectionData> result = new FacadeUpdateResult<CollectionData>();
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();
            Collection instance = RetrieveOrNew<CollectionData, Collection, ICollectionService>(result.ValidationResult, instanceId);
            if (instance != null)
            {
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "CollectionCannotBeFound");
            }

            return result;
        }

        internal IFacadeUpdateResult<CollectionData> DeleteCollectionItem(object parentId, object childId)
        {
            ArgumentValidator.IsNotNull("parentId", parentId);
            ArgumentValidator.IsNotNull("childId", childId);

            FacadeUpdateResult<CollectionData> result = new FacadeUpdateResult<CollectionData>();
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();
            Collection parent = RetrieveOrNew<CollectionData, Collection, ICollectionService>(result.ValidationResult, parentId);
            if (parent != null)
            {
                CollectionItem child = parent.CollectionItems.SingleOrDefault(o => object.Equals(o.Id, childId));
                if (child != null)
                {
                    parent.CollectionItems.Remove(child);
                    var saveQuery = parent.Save();
                    result.Merge(saveQuery);
                    result.AttachResult(parent.RetrieveData<CollectionData>());
                }
                else
                {
                    AddError(result.ValidationResult, "CollectionCollectionMethodCannotBeFound");
                }
            }
            else
            {
                AddError(result.ValidationResult, "CollectionCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            ICollectionService service = UnitOfWork.GetService<ICollectionService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (CollectionData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
