using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Component
{
    public class MetadataFacade : BusinessComponent
    {
        public MetadataFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            MetadataSystem = new MetadataSystem(unitOfWork);
        }

        private MetadataSystem MetadataSystem { get; set; }

        public List<TDto> RetrieveAll<TDto>(IDataConverter<MetadataData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = MetadataSystem.RetrieveAll(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }
    }
}
