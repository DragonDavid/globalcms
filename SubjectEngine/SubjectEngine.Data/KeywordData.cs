using Framework.Data;

namespace SubjectEngine.Data
{
    public class KeywordData : DataObject
    {
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual object TemplateId { get; set; }
    }
}
