using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Component
{
    public class FolderFacade : BusinessComponent
    {
        public FolderFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            FolderSystem = new FolderSystem(unitOfWork);
        }

        private FolderSystem FolderSystem { get; set; }

        public TDto RetrieveOrNewFolder<TDto>(object instanceId, IDataConverter<FolderData, TDto> converter)
            where TDto : class
        {
            return FolderSystem.RetrieveOrNewFolder(instanceId, converter);
        }

        public IFacadeUpdateResult<FolderData> SaveFolder(FolderData data)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<FolderData> result = FolderSystem.SaveFolder(data);
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

        public IFacadeUpdateResult<FolderData> SaveFolderLanguage(FolderData dto, object languageId)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<FolderData> result = FolderSystem.SaveFolderLanguage(dto, languageId);
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

        public IFacadeUpdateResult<FolderData> DeleteFolder(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<FolderData> result = FolderSystem.DeleteFolder(id);
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

        public List<TDto> GetFolders<TDto>(FolderType folderType, IDataConverter<FolderInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = FolderSystem.GetFolders(folderType, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public List<TDto> GetSubsiteRootFolders<TDto>(IDataConverter<FolderInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = FolderSystem.GetSubsiteRootFolders(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public IList<BindingListItem> GetBindingList()
        {
            return FolderSystem.GetBindingList();
        }
    }
}
