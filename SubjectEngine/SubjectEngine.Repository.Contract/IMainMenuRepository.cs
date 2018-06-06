using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IMainMenuRepository : IUpdateEntityRepository<MainMenuData>
    {
        IEnumerable<MainMenuData> GetPublishedMenus();
    }
}
