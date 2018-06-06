using Framework.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Repository.Contract
{
    public interface IReviewRepository : IUpdateEntityRepository<ReviewData>
    {
        IEnumerable<ReviewData> SearchByReference(object id);
    }
}
