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
    internal class SubitemValueSystem : BusinessComponent
    {
        public SubitemValueSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal TDto RetrieveOrNewSubitemValue<TDto>(object instanceId, IDataConverter<SubitemValueData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ISubitemValueService service = UnitOfWork.GetService<ISubitemValueService>();
            FacadeUpdateResult<SubitemValueData> result = new FacadeUpdateResult<SubitemValueData>();
            SubitemValue instance = RetrieveOrNew<SubitemValueData, SubitemValue, ISubitemValueService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<SubitemValueData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<ReferenceData> SaveSubitemValues(object referenceId, IList<SubitemValueData> values)
        {
            ArgumentValidator.IsNotNull("referenceId", referenceId);
            ArgumentValidator.IsNotNull("values", values);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();

            List<SubitemValue> instances = new List<SubitemValue>();
            foreach (SubitemValueData item in values)
            {
                SubitemValue instance = RetrieveOrNew<SubitemValueData, SubitemValue, ISubitemValueService>(result.ValidationResult, item.Id);
                if (!result.IsSuccessful)
                {
                    break;
                }
                instances.Add(instance);
                instance.ReferenceId = referenceId;
                instance.SubitemId = item.SubitemId;
                instance.ValueText = item.ValueText;
                instance.ValueHtml = item.ValueHtml;
                instance.ValueDate = item.ValueDate;
                instance.ValueInt = item.ValueInt;
                instance.ValueUrl = item.ValueUrl;
            }

            if (result.IsSuccessful)
            {
                ISubitemValueService service = UnitOfWork.GetService<ISubitemValueService>();
                var saveQuery = service.SaveAll(instances);
                result.Merge(saveQuery);

                //List<SubitemValueData> dataList = new List<SubitemValueData>();
                //foreach (SubitemValue instance in instances)
                //{
                //    dataList.Add(instance.RetrieveData<SubitemValueData>());
                //}
                //result.AttachResult(dataList);
            }

            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> SaveSubitemValueLanguages(IList<SubitemValueData> values, object languageId)
        {
            ArgumentValidator.IsNotNull("values", values);
            ArgumentValidator.IsNotNull("languageId", languageId);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();

            List<SubitemValue> instances = new List<SubitemValue>();
            foreach (SubitemValueData item in values)
            {
                SubitemValue instance = RetrieveOrNew<SubitemValueData, SubitemValue, ISubitemValueService>(result.ValidationResult, item.Id);
                if (!result.IsSuccessful || instance.IsNew)
                {
                    break;
                }
                instances.Add(instance);
                SubitemValueLanguage valueLanguage = instance.SubitemValueLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, languageId));
                if (valueLanguage == null)
                {
                    valueLanguage = instance.SubitemValueLanguages.AddNewBo();
                    valueLanguage.LanguageId = languageId;
                }
                valueLanguage.ValueText = item.ValueText;
                valueLanguage.ValueHtml = item.ValueHtml;
            }

            if (result.IsSuccessful)
            {
                ISubitemValueService service = UnitOfWork.GetService<ISubitemValueService>();
                var saveQuery = service.SaveAll(instances);
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<SubitemValueData> DeleteSubitemValue(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<SubitemValueData> result = new FacadeUpdateResult<SubitemValueData>();
            ISubitemValueService service = UnitOfWork.GetService<ISubitemValueService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                SubitemValue instance = query.ToBo<SubitemValue>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "SubitemValueCannotBeFound");
            }

            return result;
        }
    }
}
