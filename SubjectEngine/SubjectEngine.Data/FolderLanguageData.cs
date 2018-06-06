using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class FolderLanguageData : ChildDataObject
    {
        public virtual object LanguageId { get; set; }
        public virtual string Name { get; set; }
    }
}
