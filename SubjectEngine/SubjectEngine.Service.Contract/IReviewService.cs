using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Service.Contract
{
    public interface IReviewService : IUpdateEntityService<ReviewData>
    {
        IServiceQueryResultList<ReviewData> SearchByReference(object id);
    }
}
