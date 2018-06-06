using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class MainMenuFacade : BusinessComponent
    {
        public MainMenuFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            MainMenuSystem = new MainMenuSystem(unitOfWork);
        }

        private MainMenuSystem MainMenuSystem { get; set; }

        public List<TDto> RetrieveAllMainMenu<TDto>(IDataConverter<MainMenuData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = MainMenuSystem.RetrieveAllMainMenu(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public List<TDto> GetPublishedMenus<TDto>(IDataConverter<MainMenuData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = MainMenuSystem.GetPublishedMenus(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        //public IEnumerable<TDto> GetTopMenusWithSubMenus(IDataConverter<MainMenuData, TDto> converter)
        //    where TDto : class
        //{
        //    IEnumerable<MainMenuDto> topItems = RetrieveAllMainMenu().Where(o => o.ParentId == null);
        //    IEnumerable<MainMenuDto> Subitems = RetrieveAllMainMenu().Where(o => o.ParentId != null);
        //    // Loop to get sub menus
        //    foreach (MainMenuDto item in topItems)
        //    {
        //        item.SubMenus = Subitems.Where(o => object.Equals(o.ParentId, item.Id));
        //    }

        //    return topItems;
        //}

        public TDto RetrieveOrNewMainMenu<TDto>(object instanceId, IDataConverter<MainMenuData, TDto> converter)
            where TDto : class
        {
            return MainMenuSystem.RetrieveOrNewMainMenu(instanceId, converter);
        }

        public IFacadeUpdateResult<MainMenuData> SaveMainMenu(MainMenuData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<MainMenuData> result = MainMenuSystem.SaveMainMenu(dto);
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

        public IFacadeUpdateResult<MainMenuData> DeleteMainMenu(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<MainMenuData> result = MainMenuSystem.DeleteMainMenu(id);
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
            return MainMenuSystem.GetBindingList();
        }
    }
}
