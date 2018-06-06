﻿using Framework.Business;
using SubjectEngine.Data;
using Framework.Validation;

namespace SubjectEngine.Business
{
    public class MainMenu : BusinessObject<MainMenuData>
    {
        [RequiredField("MainMenuNameRequired", "The Name must be defined.")]
        [StringLength("MainMenuNameLength", "The Name must have a length less than {1}", MaxLength = 50)]
        public string Name
        {
            get
            {
                return Data.Name;
            }
            set
            {
                Data.Name = value;
            }
        }

        [StringLength("MainMenuMenuTextLength", "The MenuText must have a length less than {1}", MaxLength = 100)]
        public string MenuText
        {
            get
            {
                return Data.MenuText;
            }
            set
            {
                Data.MenuText = value;
            }
        }

        [StringLength("MainMenuTooltipLength", "The Tooltip must have a length less than {1}", MaxLength = 200)]
        public string Tooltip
        {
            get
            {
                return Data.Tooltip;
            }
            set
            {
                Data.Tooltip = value;
            }
        }

        [StringLength("MainMenuNavigateUrlLength", "The NavigateUrl must have a length less than {1}", MaxLength = 100)]
        public string NavigateUrl
        {
            get
            {
                return Data.NavigateUrl;
            }
            set
            {
                Data.NavigateUrl = value;
            }
        }

        public int Sort
        {
            get
            {
                return Data.Sort;
            }
            set
            {
                Data.Sort = value;
            }
        }

        public object ParentId
        {
            get { return Data.ParentId; }
            set { Data.ParentId = value; }
        }
    }
}
