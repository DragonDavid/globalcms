using System.Collections.Generic;
using Framework.Data;
using System;

namespace SubjectEngine.Data
{
    public class ReferenceData : DataObject
    {
        public ReferenceData()
        {
            ReferenceLanguages = new List<ReferenceLanguageData>();
            ReferenceCategorys = new List<ReferenceCategoryData>();
            ReferenceKeywords = new List<ReferenceKeywordData>();
            Values = new List<SubitemValueData>();
            GridRows = new List<GridRowData>();
        }

        public virtual object FolderId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Title { get; set; }
        public virtual string ThumbnailUrl { get; set; }
        public virtual string Description { get; set; }
        public virtual string Keywords { get; set; }
        public virtual object TemplateId { get; set; }
        public virtual object LocationId { get; set; }
        public virtual object CreatedById { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual bool IsMaster { get; set; }
        public virtual bool EnableAds { get; set; }
        public virtual bool EnableTopAd { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual IList<ReferenceLanguageData> ReferenceLanguages { get; set; }
        public virtual IList<ReferenceCategoryData> ReferenceCategorys { get; set; }
        public virtual IList<ReferenceKeywordData> ReferenceKeywords { get; set; }
        public virtual IList<SubitemValueData> Values { get; set; }
        public virtual IList<GridRowData> GridRows { get; set; }
    }
}
