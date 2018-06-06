using Framework.Business;
using Framework.Validation;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class Folder : BusinessObject<FolderData>
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            FolderLanguages = new ChildBoCollection<FolderData, FolderLanguage, FolderLanguageData>
                (Service, Data.FolderLanguages, this);
        }

        [ChildCollection]
        public ChildBoCollection<FolderData, FolderLanguage, FolderLanguageData> FolderLanguages
        {
            get;
            private set;
        }
        
        [RequiredField("FolderNameRequired", "The Name must be defined.")]
        [StringLength("FolderNameLength", "The Name must have a length less than {1}", MaxLength = 200)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        public object ParentId
        {
            get { return Data.ParentId; }
            set { Data.ParentId = value; }
        }


        [StringLength("FolderSlugLength", "The Slug must have a length less than {1}", MaxLength = 200)]
        public string Slug
        {
            get { return Data.Slug; }
            set { Data.Slug = value; }
        }

        public FolderType FolderType
        {
            get { return Data.FolderType; }
            set { Data.FolderType = value; }
        }

        public bool IsPublished
        {
            get { return Data.IsPublished; }
            set { Data.IsPublished = value; }
        }

        public bool IsSubsiteRoot
        {
            get { return Data.IsSubsiteRoot; }
            set { Data.IsSubsiteRoot = value; }
        }

        public int Sort
        {
            get { return Data.Sort; }
            set { Data.Sort = value; }
        }
    }
}
