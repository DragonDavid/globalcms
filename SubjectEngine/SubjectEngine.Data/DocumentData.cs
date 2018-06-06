using System;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class DocumentData : DataObject
    {
        public virtual string Title { get; set; }
        public virtual string FileName { get; set; }
        public virtual string ContentUri { get; set; }
        public virtual int DocTypeId { get; set; }
        public virtual object IssuedById { get; set; }
        public virtual DateTime IssuedDate { get; set; }
        public virtual string Extension { get; set; }
        public virtual string ContentType { get; set; }
        public virtual int ContentLength { get; set; }
    }
}
