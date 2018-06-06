using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface IUserService : IUpdateEntityService<UserData>
    {
        IServiceQueryResult<UserData> RetrieveByCredential(string email, string password);
        bool IsExists(string email);
    }
}
