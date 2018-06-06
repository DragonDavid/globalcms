using Framework.Data;

namespace SubjectEngine.Data
{
    public class CategoryData : DataObject
    {
        public virtual string CategoryText { get; set; }
        public virtual string Slug { get; set; }
        public virtual object TemplateId { get; set; }
    }
}
