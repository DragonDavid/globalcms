using System.Collections.Generic;
using Framework.Core;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class DocumentRepository : NHUpdateEntityRepository<DocumentData>, IDocumentRepository
    {
        public IEnumerable<DocumentData> SearchByUser(object userId)
        {
            ArgumentValidator.IsNotNull("userId", userId);

            IEnumerable<DocumentData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<DocumentData>();
                query.AddExpressionEq<DocumentData, object>(o => o.IssuedById, userId);

                result = query.Future<DocumentData>();
            });

            return result;
        }
    }
}
