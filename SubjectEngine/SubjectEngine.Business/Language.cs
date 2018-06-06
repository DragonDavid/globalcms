using Framework.Business;
using SubjectEngine.Data;
using Framework.Validation;

namespace SubjectEngine.Business
{
    public class Language : BusinessObject<LanguageData>
    {
        [RequiredField("LanguageNameRequired", "The Name must be defined.")]
        [StringLength("LanguageNameLength", "The Name must have a length less than {1}", MaxLength = 100)]
        public string Name
        {
            get
            {
                return Data.Name;
            }
            set
            {
                Data.Name = value;
            }
        }

        [StringLength("LanguageLabelLength", "The Label must have a length less than {1}", MaxLength = 100)]
        public string Label
        {
            get
            {
                return Data.Label;
            }
            set
            {
                Data.Label = value;
            }
        }
    }
}
