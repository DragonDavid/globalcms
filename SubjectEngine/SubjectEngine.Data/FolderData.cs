using Framework.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class FolderData : DataObject
    {
        public FolderData()
        {
            FolderLanguages = new List<FolderLanguageData>();
        }

        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual object ParentId { get; set; }
        public virtual FolderType FolderType { get; set; }
        public virtual bool IsSubsiteRoot { get; set; }
        public virtual int Sort { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual IList<FolderLanguageData> FolderLanguages { get; set; }
    }
}
