using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class SubitemValueLanguage : ChildBusinessObject<SubitemValue, SubitemValueLanguageData>
    {
        public object LanguageId
        {
            get { return Data.LanguageId; }
            set { Data.LanguageId = value; }
        }

        [StringLength("SubitemValueLanguageValueTextLength", "The Text must have a length less than {1}", MaxLength = 3000)]
        public string ValueText
        {
            get { return Data.ValueText; }
            set { Data.ValueText = value; }
        }

        public string ValueHtml
        {
            get { return Data.ValueHtml; }
            set { Data.ValueHtml = value; }
        }
    }
}
