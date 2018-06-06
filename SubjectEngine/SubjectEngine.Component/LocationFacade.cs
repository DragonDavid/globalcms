using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class LocationFacade : BusinessComponent
    {
        public LocationFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            LocationSystem = new LocationSystem(unitOfWork);
        }

        private LocationSystem LocationSystem { get; set; }

        public List<TDto> RetrieveAllLocation<TDto>(IDataConverter<LocationData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = LocationSystem.RetrieveAllLocation(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public List<TDto> GetPublishedLocations<TDto>(IDataConverter<LocationData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = LocationSystem.GetPublishedLocations(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public TDto RetrieveOrNewLocation<TDto>(object instanceId, IDataConverter<LocationData, TDto> converter)
            where TDto : class
        {
            return LocationSystem.RetrieveOrNewLocation(instanceId, converter);
        }

        public IFacadeUpdateResult<LocationData> SaveLocation(LocationData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<LocationData> result = LocationSystem.SaveLocation(dto);
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

        public IFacadeUpdateResult<LocationData> DeleteLocation(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<LocationData> result = LocationSystem.DeleteLocation(id);
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
            return LocationSystem.GetBindingList();
        }
    }
}
