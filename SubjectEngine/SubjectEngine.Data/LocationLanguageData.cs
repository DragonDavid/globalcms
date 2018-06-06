using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class LocationLanguageData : ChildDataObject
    {
        public virtual object LanguageId { get; set; }
        public virtual string Name { get; set; }
    }
}
