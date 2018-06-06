using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Component
{
    public class SubsiteFacade : BusinessComponent
    {
        public SubsiteFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            SubsiteSystem = new SubsiteSystem(unitOfWork);
        }

        private SubsiteSystem SubsiteSystem { get; set; }

        public TDto GetSubsiteInfo<TDto>(object instanceId, IDataConverter<SubsiteInfoData, TDto> converter)
            where TDto : class
        {
            return SubsiteSystem.GetSubsiteInfo(instanceId, converter);
        }

        public TDto RetrieveOrNewSubsite<TDto>(object instanceId, IDataConverter<SubsiteData, TDto> converter)
            where TDto : class
        {
            return SubsiteSystem.RetrieveOrNewSubsite(instanceId, converter);
        }

        public IFacadeUpdateResult<SubsiteData> SaveSubsite(SubsiteData data)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<SubsiteData> result = SubsiteSystem.SaveSubsite(data);
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

        public IFacadeUpdateResult<SubsiteData> DeleteSubsite(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<SubsiteData> result = SubsiteSystem.DeleteSubsite(id);
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

        public List<TDto> GetSubsites<TDto>(IDataConverter<SubsiteBriefData, TDto> converter, bool isPublished = false)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = SubsiteSystem.GetSubsites(converter, isPublished);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }
    }
}
