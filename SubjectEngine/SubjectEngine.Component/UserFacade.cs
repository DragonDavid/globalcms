using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class UserFacade : BusinessComponent
    {
        public UserFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UserSystem = new UserSystem(unitOfWork);
        }

        private UserSystem UserSystem { get; set; }

        public IEnumerable<TDto> RetrieveAllUser<TDto>(IDataConverter<UserData, TDto> converter)
            where TDto : class
        {
            IEnumerable<TDto> instances = UserSystem.RetrieveAllUser(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveOrNewUser<TDto>(object instanceId, IDataConverter<UserData, TDto> converter)
            where TDto : class
        {
            return UserSystem.RetrieveOrNewUser(instanceId, converter);
        }

        public IFacadeUpdateResult<UserData> SaveUser(UserData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<UserData> result = UserSystem.SaveUser(dto);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }
            return result;
        }

        public IFacadeUpdateResult<UserData> DeleteUser(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<UserData> result = UserSystem.DeleteUser(id);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }
            return result;
        }

        public IList<BindingListItem> GetBindingList()
        {
            return UserSystem.GetBindingList();
        }
    }
}
