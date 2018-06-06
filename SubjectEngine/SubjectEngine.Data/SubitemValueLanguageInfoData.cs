using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class SubitemValueLanguageInfoData : ChildDataObject
    {
        public virtual object LanguageId { get; set; }
        public virtual string ValueText { get; set; }
        public virtual string ValueHtml { get; set; }
    }
}
