using Framework.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class FolderInfoData : DataObject
    {
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual object ParentId { get; set; }
        public virtual FolderType FolderType { get; set; }
        public virtual string FullName { get; set; }
        public virtual string FullSlug { get; set; }
        public virtual bool IsSubsiteRoot { get; set; }
        public virtual object SubsiteFolderId { get; set; }
        public virtual int Sort { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual IEnumerable<FolderLanguageInfoData> FolderLanguages { get; set; }
    }
}
