using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class ReviewService : UpdateEntityService<IReviewRepository, ReviewData>, IReviewService
    {
        public IServiceQueryResultList<ReviewData> SearchByReference(object id)
        {
            IEnumerable<ReviewData> result = Repository.SearchByReference(id);
            return ServiceResultFactory.BuildServiceQueryResult<ReviewData>(result);
        }
    }
}
