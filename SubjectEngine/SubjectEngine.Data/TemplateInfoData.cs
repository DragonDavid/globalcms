using System.Collections.Generic;
using Framework.Data;
using System;

namespace SubjectEngine.Data
{
    public class TemplateInfoData : DataObject
    {
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual bool HideTitle { get; set; }
        public virtual bool EnableReview { get; set; }
        public virtual bool EnableCategory { get; set; }
        public virtual bool EnableLocation { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int RelatedContentNo { get; set; }
        public virtual IEnumerable<ZoneInfoData> Zones { get; set; }
        public virtual IEnumerable<CategoryData> Categorys { get; set; }
        public virtual IEnumerable<KeywordData> Keywords { get; set; }
    }
}
