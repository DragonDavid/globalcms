using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class SubsiteMenuData : ChildDataObject
    {
        public virtual string MenuText { get; set; }
        public virtual string NavigateUrl { get; set; }
        public virtual string Tooltip { get; set; }
        public virtual int Sort { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual IEnumerable<SubsiteMenuLanguageData> SubsiteMenuLanguages { get; set; }
    }
}
