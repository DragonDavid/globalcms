using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class ApplicationSettingFacade : BusinessComponent
    {
        public ApplicationSettingFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            ApplicationSettingSystem = new ApplicationSettingSystem(unitOfWork);
        }

        private ApplicationSettingSystem ApplicationSettingSystem { get; set; }

        public IEnumerable<TDto> RetrieveAllApplicationSetting<TDto>(IDataConverter<ApplicationSettingData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            IEnumerable<TDto> instances = ApplicationSettingSystem.RetrieveAllApplicationSetting(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public IFacadeUpdateResult<ApplicationSettingData> SaveApplicationSetting(ApplicationSettingData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ApplicationSettingData> result = ApplicationSettingSystem.SaveApplicationSetting(dto);
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

        public IFacadeUpdateResult<ApplicationSettingData> DeleteApplicationSetting(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ApplicationSettingData> result = ApplicationSettingSystem.DeleteApplicationSetting(id);
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

        public ApplicationOption GetApplicationOption()
        {
            UnitOfWork.BeginTransaction();
            ApplicationOption result = ApplicationSettingSystem.GetApplicationOption();
            UnitOfWork.CommitTransaction();
            return result;
        }

        public IList<BindingListItem> GetBindingList()
        {
            return ApplicationSettingSystem.GetBindingList();
        }
    }
}
