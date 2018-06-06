using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class TemplateFacade : BusinessComponent
    {
        public TemplateFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            TemplateSystem = new TemplateSystem(unitOfWork);
        }

        private TemplateSystem TemplateSystem { get; set; }

        public List<TDto> GetTemplatesInfo<TDto>(IDataConverter<TemplateInfoData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = TemplateSystem.GetTemplatesInfo(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto GetTemplateInfo<TDto>(object instanceId, IDataConverter<TemplateInfoData, TDto> converter)
            where TDto : class
        {
            return TemplateSystem.GetTemplateInfo(instanceId, converter);
        }

        public List<TDto> RetrieveAllTemplate<TDto>(IDataConverter<TemplateData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = TemplateSystem.RetrieveAllTemplate(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveOrNewTemplate<TDto>(object instanceId, IDataConverter<TemplateData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = TemplateSystem.RetrieveOrNewTemplate(instanceId, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public IFacadeUpdateResult<TemplateData> SaveTemplate(TemplateData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<TemplateData> result = TemplateSystem.SaveTemplate(dto);
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

        public IFacadeUpdateResult<TemplateData> DeleteTemplate(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<TemplateData> result = TemplateSystem.DeleteTemplate(id);
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
            return TemplateSystem.GetBindingList();
        }
    }
}
