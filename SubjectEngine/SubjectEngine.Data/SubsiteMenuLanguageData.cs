using Framework.Data;

namespace SubjectEngine.Data
{
    public class SubsiteMenuLanguageData : ChildDataObject
    {
        public virtual object LanguageId { get; set; }
        public virtual string MenuText { get; set; }
    }
}
