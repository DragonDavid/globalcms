using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class FolderLanguage : ChildBusinessObject<Folder, FolderLanguageData>
    {
        public object LanguageId
        {
            get { return Data.LanguageId; }
            set { Data.LanguageId = value; }
        }

        [StringLength("FolderLanguageNameLength", "The Name must have a length less than {1}", MaxLength = 200)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }
    }
}
