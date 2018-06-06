using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IDocumentRepository : IUpdateEntityRepository<DocumentData>
    {
        IEnumerable<DocumentData> SearchByUser(object userId);
    }
}
