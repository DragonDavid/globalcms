using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IUserRepository : IUpdateEntityRepository<UserData>
    {
        UserData RetrieveByCredential(string email, string password);
        bool IsExists(string email);
    }
}
