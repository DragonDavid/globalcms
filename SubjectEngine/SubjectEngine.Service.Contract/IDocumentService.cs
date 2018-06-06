using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface IDocumentService : IUpdateEntityService<DocumentData>
    {
        IServiceQueryResultList<DocumentData> SearchByUser(object userId);
    }
}
