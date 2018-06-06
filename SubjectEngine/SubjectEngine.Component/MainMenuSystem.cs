﻿using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Business;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class MainMenuSystem : BusinessComponent
    {
        public MainMenuSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> RetrieveAllMainMenu<TDto>(IDataConverter<MainMenuData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IMainMenuService service = UnitOfWork.GetService<IMainMenuService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> GetPublishedMenus<TDto>(IDataConverter<MainMenuData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IMainMenuService service = UnitOfWork.GetService<IMainMenuService>();

            var query = service.GetPublishedMenus();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveOrNewMainMenu<TDto>(object instanceId, IDataConverter<MainMenuData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IMainMenuService service = UnitOfWork.GetService<IMainMenuService>();
            FacadeUpdateResult<MainMenuData> result = new FacadeUpdateResult<MainMenuData>();
            MainMenu instance = RetrieveOrNew<MainMenuData, MainMenu, IMainMenuService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<MainMenuData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<MainMenuData> SaveMainMenu(MainMenuData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<MainMenuData> result = new FacadeUpdateResult<MainMenuData>();
            IMainMenuService service = UnitOfWork.GetService<IMainMenuService>();
            MainMenu instance = RetrieveOrNew<MainMenuData, MainMenu, IMainMenuService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.MenuText = dto.MenuText;
                instance.Tooltip = dto.Tooltip;
                instance.NavigateUrl = dto.NavigateUrl;
                instance.Sort = dto.Sort;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<MainMenuData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<MainMenuData> DeleteMainMenu(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<MainMenuData> result = new FacadeUpdateResult<MainMenuData>();
            IMainMenuService service = UnitOfWork.GetService<IMainMenuService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                MainMenu instance = query.ToBo<MainMenu>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "MainMenuCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            IMainMenuService service = UnitOfWork.GetService<IMainMenuService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (MainMenuData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
