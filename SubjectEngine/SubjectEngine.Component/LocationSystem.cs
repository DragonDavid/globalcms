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
    internal class LocationSystem : BusinessComponent
    {
        public LocationSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> RetrieveAllLocation<TDto>(IDataConverter<LocationData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ILocationService service = UnitOfWork.GetService<ILocationService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> GetPublishedLocations<TDto>(IDataConverter<LocationData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ILocationService service = UnitOfWork.GetService<ILocationService>();

            var query = service.GetPublishedLocations();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveOrNewLocation<TDto>(object instanceId, IDataConverter<LocationData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ILocationService service = UnitOfWork.GetService<ILocationService>();
            FacadeUpdateResult<LocationData> result = new FacadeUpdateResult<LocationData>();
            Location instance = RetrieveOrNew<LocationData, Location, ILocationService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<LocationData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<LocationData> SaveLocation(LocationData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<LocationData> result = new FacadeUpdateResult<LocationData>();
            ILocationService service = UnitOfWork.GetService<ILocationService>();
            Location instance = RetrieveOrNew<LocationData, Location, ILocationService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.IsPublished = dto.IsPublished;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<LocationData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<LocationData> DeleteLocation(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<LocationData> result = new FacadeUpdateResult<LocationData>();
            ILocationService service = UnitOfWork.GetService<ILocationService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Location instance = query.ToBo<Location>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "LocationCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            ILocationService service = UnitOfWork.GetService<ILocationService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (LocationData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
