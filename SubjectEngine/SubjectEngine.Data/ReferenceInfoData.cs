using System;
using System.Collections.Generic;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class ReferenceInfoData : DataObject
    {
        public virtual string UrlAlias { get; set; }
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Title { get; set; }
        public virtual string ThumbnailUrl { get; set; }
        public virtual string Description { get; set; }
        public virtual string Keywords { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Folder { get; set; }
        public virtual object FolderId { get; set; }
        public virtual bool HideTitle { get; set; }
        public virtual bool EnableReview { get; set; }
        public virtual bool EnableCategory { get; set; }
        public virtual bool EnableLocation { get; set; }
        public virtual bool EnableAds { get; set; }
        public virtual bool EnableTopAd { get; set; }
        public virtual object SubsiteId { get; set; }
        public virtual object LocationId { get; set; }
        public virtual string LocationName { get; set; }
        public virtual TemplateInfoData Template { get; set; }
        public virtual IEnumerable<SubitemValueInfoData> Values { get; set; }
        public virtual IEnumerable<GridRowInfoData> GridRows { get; set; }
        public virtual IEnumerable<ReferenceCategoryInfoData> ReferenceCategorys { get; set; }
        public virtual IEnumerable<ReferenceKeywordInfo> ReferenceKeywords { get; set; }
        public virtual IEnumerable<ReferenceLanguageInfoData> ReferenceLanguages { get; set; }
        public virtual IEnumerable<SubjectInfoData> RelatedSubjects { get; set; }
    }
}
