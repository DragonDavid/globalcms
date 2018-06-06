using System.Collections.Generic;
using System.Linq;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Component
{
    internal class SubjectSystem : BusinessComponent
    {
        public SubjectSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal IList<TDto> RetrieveAllSubject<TDto>(IDataConverter<SubjectData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            ISubjectService service = UnitOfWork.GetService<ISubjectService>();

            var query = service.GetAll();
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveSubject<TDto>(object subjectId, IDataConverter<SubjectData, TDto> converter)
            where TDto : BaseDto
        {
            ArgumentValidator.IsNotNull("subjectId", subjectId);
            ArgumentValidator.IsNotNull("converter", converter);

            ISubjectService service = UnitOfWork.GetService<ISubjectService>();
            var query = service.Retrieve(subjectId);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }

            return null;
        }

        internal TDto RetrieveSubjectByType<TDto>(string subjectType, IDataConverter<SubjectData, TDto> converter)
            where TDto : BaseDto
        {
            ArgumentValidator.IsNotNull("subjectType", subjectType);
            ArgumentValidator.IsNotNull("converter", converter);

            ISubjectService service = UnitOfWork.GetService<ISubjectService>();
            var query = service.RetrieveBySubjectType(subjectType);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }

            return null;
        }
    }
}
