using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Service.Contract
{
    public interface ISubjectService : IUpdateEntityService<SubjectData>
    {
        IServiceQueryResult<SubjectData> RetrieveBySubjectType(string subjectType);
        IEnumerable<SubjectFieldInfoData> GetSubjectFieldInfosData(object subjectId);
    }
}
