using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Business;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class TemplateSystem : BusinessComponent
    {
        public TemplateSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> GetTemplatesInfo<TDto>(IDataConverter<TemplateInfoData, TDto> converter)
            where TDto : class
        {
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            var query = service.GetTemplatesInfo();
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto GetTemplateInfo<TDto>(object instanceId, IDataConverter<TemplateInfoData, TDto> converter)
            where TDto : class
        {
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            var query = service.GetTemplateInfo(instanceId);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }

            return null;
        }

        internal List<TDto> RetrieveAllTemplate<TDto>(IDataConverter<TemplateData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveOrNewTemplate<TDto>(object instanceId, IDataConverter<TemplateData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            FacadeUpdateResult<TemplateData> result = new FacadeUpdateResult<TemplateData>();
            Template instance = RetrieveOrNew<TemplateData, Template, ITemplateService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<TemplateData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<TemplateData> SaveTemplate(TemplateData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<TemplateData> result = new FacadeUpdateResult<TemplateData>();
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            Template instance = RetrieveOrNew<TemplateData, Template, ITemplateService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.Slug = dto.Slug;
                instance.HideTitle = dto.HideTitle;
                instance.EnableReview = dto.EnableReview;
                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<TemplateData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<TemplateData> DeleteTemplate(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<TemplateData> result = new FacadeUpdateResult<TemplateData>();
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Template instance = query.ToBo<Template>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "TemplateCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (TemplateData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
