using System;

namespace SubjectEngine.Data
{
    public class AliasInfoData
    {
        public virtual string UrlAlias { get; set; }
        public virtual string Folder { get; set; }
        public virtual int ReferenceId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Template { get; set; }
    }
}
