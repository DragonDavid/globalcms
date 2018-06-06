using Framework.Core;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using System.Collections.Generic;

namespace SubjectEngine.Repository
{
    public class ReviewRepository : NHUpdateEntityRepository<ReviewData>, IReviewRepository
    {
        public IEnumerable<ReviewData> SearchByReference(object id)
        {
            ArgumentValidator.IsNotNull("id", id);

            IEnumerable<ReviewData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<ReviewData>();
                query.AddExpressionEq<ReviewData, object>(o => o.ReferenceId, id);

                result = query.Future<ReviewData>();
            });

            return result;
        }
    }
}
