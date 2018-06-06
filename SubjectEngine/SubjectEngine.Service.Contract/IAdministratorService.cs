using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Service.Contract
{
    public interface IAdministratorService : IUpdateEntityService<AdministratorData>
    {
        IServiceQueryResult<AdministratorData> RetrieveByCredential(string username, string password);
        bool IsExists(string email);
    }
}
