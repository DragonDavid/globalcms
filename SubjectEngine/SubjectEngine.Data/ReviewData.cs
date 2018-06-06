using Framework.Data;
using System;

namespace SubjectEngine.Data
{
    public class ReviewData : DataObject
    {
        public virtual object ReferenceId { get; set; }
        public virtual decimal? Rating { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual string IssuedBy { get; set; }
        public virtual string IssuedByEmail { get; set; }
        public virtual DateTime IssuedTime { get; set; }
        public virtual bool IsPublished { get; set; }
    }
}
