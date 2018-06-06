using Framework.Service;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class CollectionService : UpdateEntityService<ICollectionRepository, CollectionData>, ICollectionService
    {
    }
}
