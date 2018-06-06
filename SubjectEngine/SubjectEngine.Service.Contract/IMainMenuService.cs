using SubjectEngine.Data;
using Framework.Service;
using Framework.UoW;

namespace SubjectEngine.Service.Contract
{
    public interface IMainMenuService : IUpdateEntityService<MainMenuData>
    {
        IServiceQueryResultList<MainMenuData> GetPublishedMenus();
    }
}
