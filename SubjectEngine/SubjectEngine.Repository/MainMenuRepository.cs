using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using Framework.Data.NHibernate;
using System.Collections.Generic;
using Framework.Data;
using NHibernate;

namespace SubjectEngine.Repository
{
    public class MainMenuRepository : NHUpdateEntityRepository<MainMenuData>, IMainMenuRepository
    {
        public IEnumerable<MainMenuData> GetPublishedMenus()
        {
            IEnumerable<MainMenuData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<MainMenuData>();
                query.AddExpressionEq<MainMenuData, bool>(o => o.IsPublished, true);
                result = query.List<MainMenuData>();
            });

            return result;
        }
    }
}
