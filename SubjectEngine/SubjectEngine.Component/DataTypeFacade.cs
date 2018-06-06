using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Component
{
    public class DataTypeFacade : BusinessComponent
    {
        public DataTypeFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            DataTypeSystem = new DataTypeSystem(unitOfWork);
        }

        private DataTypeSystem DataTypeSystem { get; set; }

        public List<TDto> RetrieveAll<TDto>(IDataConverter<DataTypeData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = DataTypeSystem.RetrieveAll(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public IEnumerable<BindingListItem> GetBindingList()
        {
            return DataTypeSystem.GetBindingList();
        }
    }
}
