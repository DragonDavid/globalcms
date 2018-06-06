using System;
using System.Collections.Generic;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class TemplateData : DataObject
    {
        public TemplateData()
        {
            ZonesData = new List<ZoneData>();
            CategorysData = new List<CategoryData>();
        }

        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual bool HideTitle { get; set; }
        public virtual bool EnableReview { get; set; }
        public virtual bool EnableCategory { get; set; }
        public virtual bool EnableLocation { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int RelatedContentNo { get; set; }
        public virtual IEnumerable<ZoneData> ZonesData { get; set; }
        public virtual IEnumerable<CategoryData> CategorysData { get; set; }
        public virtual IEnumerable<KeywordData> KeywordsData { get; set; }
    }
}
