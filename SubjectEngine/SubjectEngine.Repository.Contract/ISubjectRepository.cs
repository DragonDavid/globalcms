using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface ISubjectRepository : IUpdateEntityRepository<SubjectData>
    {
        SubjectData RetrieveBySubjectType(string subjectType);

        IEnumerable<SubjectFieldInfoData> GetSubjectFieldInfosData(object subjectId);
    }
}
