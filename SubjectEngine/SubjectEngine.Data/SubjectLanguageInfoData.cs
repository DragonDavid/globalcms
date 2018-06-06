using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class SubjectLanguageInfoData : ChildDataObject
    {
        public virtual object LanguageId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
