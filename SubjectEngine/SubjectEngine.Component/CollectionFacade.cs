using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Component
{
    public class CollectionFacade : BusinessComponent
    {
        public CollectionFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            CollectionSystem = new CollectionSystem(unitOfWork);
        }

        private CollectionSystem CollectionSystem { get; set; }

        public List<TDto> RetrieveAllCollection<TDto>(IDataConverter<CollectionData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = CollectionSystem.RetrieveAllCollection(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveOrNewCollection<TDto>(object instanceId, IDataConverter<CollectionData, TDto> converter)
            where TDto : class
        {
            return CollectionSystem.RetrieveOrNewCollection(instanceId, converter);
        }

        public IFacadeUpdateResult<CollectionData> SaveCollection(CollectionData data)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<CollectionData> result = CollectionSystem.SaveCollection(data);
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

        public IFacadeUpdateResult<CollectionData> DeleteCollection(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<CollectionData> result = CollectionSystem.DeleteCollection(id);
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
            return CollectionSystem.GetBindingList();
        }
    }
}
