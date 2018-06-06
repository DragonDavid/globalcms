using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class ReferenceLanguage : ChildBusinessObject<Reference, ReferenceLanguageData>
    {
        public object LanguageId
        {
            get { return Data.LanguageId; }
            set { Data.LanguageId = value; }
        }

        [StringLength("ReferenceLanguageTitleLength", "The Title must have a length less than {1}", MaxLength = 200)]
        public string Title
        {
            get { return Data.Title; }
            set { Data.Title = value; }
        }

        [StringLength("ReferenceLanguageDescriptionLength", "The Description must have a length less than {1}", MaxLength = 300)]
        public string Description
        {
            get { return Data.Description; }
            set { Data.Description = value; }
        }

        [StringLength("ReferenceLanguageKeywordsLength", "The Keywords must have a length less than {1}", MaxLength = 200)]
        public string Keywords
        {
            get { return Data.Keywords; }
            set { Data.Keywords = value; }
        }

    }
}
