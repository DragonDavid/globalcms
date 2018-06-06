using System.Collections.Generic;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service
{
    public class MainMenuService : UpdateEntityService<IMainMenuRepository, MainMenuData>, IMainMenuService
    {
        public IServiceQueryResultList<MainMenuData> GetPublishedMenus()
        {
            IEnumerable<MainMenuData> result = Repository.GetPublishedMenus();
            return ServiceResultFactory.BuildServiceQueryResult<MainMenuData>(result);
        }
    }
}
