using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class MainMenuData : DataObject
    {
        public MainMenuData()
        {
            MainMenuLanguages = new List<MainMenuLanguageData>();
        }

        public virtual string Name { get; set; }
        public virtual string MenuText { get; set; }
        public virtual string Tooltip { get; set; }
        public virtual string NavigateUrl { get; set; }
        public virtual int Sort { get; set; }
        public virtual object ParentId { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual IList<MainMenuLanguageData> MainMenuLanguages { get; set; }
    }
}
