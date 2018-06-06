using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class MainMenuLanguageData : ChildDataObject
    {
        public virtual object LanguageId { get; set; }
        public virtual string MenuText { get; set; }
    }
}
