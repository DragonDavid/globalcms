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
    internal class FolderSystem : BusinessComponent
    {
        public FolderSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal TDto RetrieveOrNewFolder<TDto>(object instanceId, IDataConverter<FolderData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            FacadeUpdateResult<FolderData> result = new FacadeUpdateResult<FolderData>();
            Folder instance = RetrieveOrNew<FolderData, Folder, IFolderService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<FolderData>());
            }
            else
            {
                return null;
            }
        }

        internal FacadeUpdateResult<FolderData> SaveFolder(FolderData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<FolderData> result = new FacadeUpdateResult<FolderData>();
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            Folder instance = RetrieveOrNew<FolderData, Folder, IFolderService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.Slug = dto.Slug;
                instance.ParentId = dto.ParentId;
                instance.FolderType = dto.FolderType;
                instance.Sort = dto.Sort;
                instance.IsPublished = dto.IsPublished;
                instance.IsSubsiteRoot = dto.IsSubsiteRoot;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<FolderData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<FolderData> SaveFolderLanguage(FolderData dto, object languageId)
        {
            ArgumentValidator.IsNotNull("dto", dto);
            ArgumentValidator.IsNotNull("languageId", languageId);

            FacadeUpdateResult<FolderData> result = new FacadeUpdateResult<FolderData>();
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            Folder instance = RetrieveOrNew<FolderData, Folder, IFolderService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                // Check existence of current language 
                FolderLanguage FolderLanguage = instance.FolderLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, languageId));
                if (FolderLanguage == null)
                {
                    FolderLanguage = instance.FolderLanguages.AddNewBo();
                    FolderLanguage.LanguageId = languageId;
                }
                FolderLanguage.Name = dto.Name;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<FolderData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<FolderData> DeleteFolder(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<FolderData> result = new FacadeUpdateResult<FolderData>();
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Folder instance = query.ToBo<Folder>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "FolderCannotBeFound");
            }

            return result;
        }

        internal List<TDto> GetFolders<TDto>(FolderType folderType, IDataConverter<FolderInfoData, TDto> converter)
            where TDto : class
        {
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            var query = service.GetFolders(folderType);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> GetSubsiteRootFolders<TDto>(IDataConverter<FolderInfoData, TDto> converter)
            where TDto : class
        {
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            var query = service.GetSubsiteRootFolders();
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            IFolderService service = UnitOfWork.GetService<IFolderService>();
            var query = service.GetSubsiteRootFolders();
            if (query.HasResult)
            {
                foreach (FolderInfoData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
