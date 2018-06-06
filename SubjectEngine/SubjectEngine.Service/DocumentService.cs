using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class DocumentService : UpdateEntityService<IDocumentRepository, DocumentData>, IDocumentService
    {
        public IServiceQueryResultList<DocumentData> SearchByUser(object userId)
        {
            IEnumerable<DocumentData> result = Repository.SearchByUser(userId);
            return ServiceResultFactory.BuildServiceQueryResult<DocumentData>(result);
        }
    }
}
