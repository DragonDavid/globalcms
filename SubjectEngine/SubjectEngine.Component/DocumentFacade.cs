using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class DocumentFacade : BusinessComponent
    {
        public DocumentFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            DocumentSystem = new DocumentSystem(unitOfWork);
        }

        private DocumentSystem DocumentSystem { get; set; }

        public List<TDto> RetrieveAllDocument<TDto>(IDataConverter<DocumentData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = DocumentSystem.RetrieveAllDocument(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveOrNewDocument<TDto>(object instanceId, IDataConverter<DocumentData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = DocumentSystem.RetrieveOrNewDocument(instanceId, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public IFacadeUpdateResult<DocumentData> SaveDocument(DocumentData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<DocumentData> result = DocumentSystem.SaveDocument(dto);
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

        public IFacadeUpdateResult<DocumentData> DeleteDocument(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<DocumentData> result = DocumentSystem.DeleteDocument(id);
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
            return DocumentSystem.GetBindingList();
        }
    }
}
