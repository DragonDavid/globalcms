using System.Collections.Generic;
using System.Linq;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using SubjectEngine.Business;

namespace SubjectEngine.Component
{
    internal class SubsiteSystem : BusinessComponent
    {
        public SubsiteSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal TDto GetSubsiteInfo<TDto>(object instanceId, IDataConverter<SubsiteInfoData, TDto> converter)
            where TDto : class
        {
            ISubsiteService service = UnitOfWork.GetService<ISubsiteService>();
            var query = service.GetSubsiteInfo(instanceId);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }

            return null;
        }

        internal TDto RetrieveOrNewSubsite<TDto>(object instanceId, IDataConverter<SubsiteData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ISubsiteService service = UnitOfWork.GetService<ISubsiteService>();
            FacadeUpdateResult<SubsiteData> result = new FacadeUpdateResult<SubsiteData>();
            Subsite instance = RetrieveOrNew<SubsiteData, Subsite, ISubsiteService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<SubsiteData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<SubsiteData> SaveSubsite(SubsiteData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<SubsiteData> result = new FacadeUpdateResult<SubsiteData>();
            ISubsiteService service = UnitOfWork.GetService<ISubsiteService>();
            Subsite instance = RetrieveOrNew<SubsiteData, Subsite, ISubsiteService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Address = dto.Address;
                instance.Phone = dto.Phone;
                instance.Fax = dto.Fax;
                instance.Email = dto.Email;
                instance.Website = dto.Website;
                instance.BackColor = dto.BackColor;
                instance.TitleColor = dto.TitleColor;
                instance.BannerUrl = dto.BannerUrl;
                if (dto.SubsiteFolderId != null)
                {
                    instance.SubsiteFolderId = dto.SubsiteFolderId;
                }
                instance.DefaultLanguageId = dto.DefaultLanguageId;
                instance.DefaultLocationId = dto.DefaultLocationId;
                instance.BannerHeight = dto.BannerHeight;
                instance.IsPublished = dto.IsPublished;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<SubsiteData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<SubsiteData> DeleteSubsite(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<SubsiteData> result = new FacadeUpdateResult<SubsiteData>();
            ISubsiteService service = UnitOfWork.GetService<ISubsiteService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Subsite instance = query.ToBo<Subsite>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "SubsiteCannotBeFound");
            }

            return result;
        }

        internal List<TDto> GetSubsites<TDto>(IDataConverter<SubsiteBriefData, TDto> converter, bool isPublished = false)
            where TDto : class
        {
            ISubsiteService service = UnitOfWork.GetService<ISubsiteService>();
            var query = service.GetSubsites(isPublished);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }
    }
}
