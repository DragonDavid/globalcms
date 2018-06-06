using System;
using System.Collections.Generic;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class SubjectInfoData : DataObject
    {
        public virtual string UrlAlias { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual object MasterSubjectId { get; set; }
        public virtual string MasterSubjectTitle { get; set; }
        public virtual string MasterSubjectUrlAlias { get; set; }
        public virtual int TotalCount { get; set; }
    }
}
