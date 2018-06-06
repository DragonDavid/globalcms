using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class AliasInfoFacade : BusinessComponent
    {
        public AliasInfoFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            AliasSystem = new AliasInfoSystem(unitOfWork);
        }

        private AliasInfoSystem AliasSystem { get; set; }

        public List<TDto> GetAllAliases<TDto>(IDataConverter<AliasInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = AliasSystem.GetAllAliases(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public TDto GetAliasInfo<TDto>(string alias, IDataConverter<AliasInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = AliasSystem.GetAliasInfo(alias, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }
    }
}
