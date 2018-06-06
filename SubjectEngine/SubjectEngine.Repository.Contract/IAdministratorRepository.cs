using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IAdministratorRepository : IUpdateEntityRepository<AdministratorData>
    {
        AdministratorData RetrieveByCredential(string email, string password);
        bool IsExists(string email);
    }
}
