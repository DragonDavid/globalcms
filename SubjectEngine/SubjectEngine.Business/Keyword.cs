using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class Keyword : BusinessObject<KeywordData>
    {
        [RequiredField("KeywordNameRequired", "The Name must be defined.")]
        [StringLength("KeywordNameLength", "The Name must have a length less than {1}", MaxLength = 50)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        [StringLength("KeywordSlugLength", "The Slug must have a length less than {1}", MaxLength = 50)]
        public string Slug
        {
            get { return Data.Slug; }
            set { Data.Slug = value; }
        }

        public object TemplateId
        {
            get { return Data.TemplateId; }
            set { Data.TemplateId = value; }
        }
    }
}
