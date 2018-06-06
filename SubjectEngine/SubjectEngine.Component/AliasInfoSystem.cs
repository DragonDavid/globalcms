using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class AliasInfoSystem : BusinessComponent
    {
        public AliasInfoSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> GetAllAliases<TDto>(IDataConverter<AliasInfoData, TDto> converter)
            where TDto : class
        {
            IAliasService service = UnitOfWork.GetService<IAliasService>();
            var query = service.GetAliases();
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto GetAliasInfo<TDto>(string alias, IDataConverter<AliasInfoData, TDto> converter)
            where TDto : class
        {
            IAliasService service = UnitOfWork.GetService<IAliasService>();
            var query = service.GetAliasInfo(alias);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }
            return null;
        }
    }
}
