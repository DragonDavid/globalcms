using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using System;

namespace SubjectEngine.Service
{
    public class AdministratorService : UpdateEntityService<IAdministratorRepository, AdministratorData>, IAdministratorService
    {
        public IServiceQueryResult<AdministratorData> RetrieveByCredential(string email, string password)
        {
            if (!email.TrimHasValue() || !password.TrimHasValue())
            {
                return ServiceResultFactory.BuildServiceQueryResult((AdministratorData)null);
            }

            AdministratorData user = Repository.RetrieveByCredential(email, password);
            //AdministratorData user = Repository.RetrieveByCredential(email, SecurityHelper.Encrypt(password));

            return ServiceResultFactory.BuildServiceQueryResult(user);
        }

        public bool IsExists(string email)
        {
            return Repository.IsExists(email);
        }
    }
}
