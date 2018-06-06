using Framework.Data;

namespace SubjectEngine.Data
{
    public class ReferenceKeywordInfo : ChildDataObject
    {
        public virtual object KeywordId { get; set; }
        public virtual string KeywordName { get; set; }
        public virtual string KeywordSlug { get; set; }
        public virtual int Sort { get; set; }
    }
}
