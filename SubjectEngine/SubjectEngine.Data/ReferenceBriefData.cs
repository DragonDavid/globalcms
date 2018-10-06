using System;
using System.Collections.Generic;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class ReferenceBriefData : DataObject
    {
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual string Slug { get; set; }
        public virtual string UrlAlias { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int? CreatedById { get; set; }
        public virtual string Template { get; set; }
        public virtual string LocationName { get; set; }
        public virtual int TotalCount { get; set; }
        public virtual IEnumerable<ReferenceBriefLanguageData> ReferenceLanguages { get; set; }
    }
}
