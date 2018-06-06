using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class SubjectService : UpdateEntityService<ISubjectRepository, SubjectData>, ISubjectService
    {
        public IServiceQueryResult<SubjectData> RetrieveBySubjectType(string subjectName)
        {
            SubjectData data = Repository.RetrieveBySubjectType(subjectName);
            return ServiceResultFactory.BuildServiceQueryResult(data);
        }

        public IEnumerable<SubjectFieldInfoData> GetSubjectFieldInfosData(object subjectId)
        {
            return Repository.GetSubjectFieldInfosData(subjectId);
        }
    }
}
