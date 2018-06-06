using Framework.Service;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class DEntityService : UpdateEntityService<IDEntityRepository, DEntityData>, IDEntityService
    {
       

    }
}
