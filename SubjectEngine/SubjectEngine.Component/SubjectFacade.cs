using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Component
{
    public class SubjectFacade : BusinessComponent
    {
        public SubjectFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            SubjectSystem = new SubjectSystem(unitOfWork);
        }

        private SubjectSystem SubjectSystem { get; set; }

        public IList<TDto> RetrieveAllSubject<TDto>(IDataConverter<SubjectData, TDto> converter)
            where TDto : class
        {
            IList<TDto> instances = SubjectSystem.RetrieveAllSubject(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveSubject<TDto>(object subjectId, IDataConverter<SubjectData, TDto> converter)
            where TDto : BaseDto
        {
            return SubjectSystem.RetrieveSubject(subjectId, converter);
        }

        public TDto RetrieveSubjectByType<TDto>(string subjectType, IDataConverter<SubjectData, TDto> converter)
            where TDto : BaseDto
        {
            return SubjectSystem.RetrieveSubjectByType(subjectType, converter);
        }
    }
}
