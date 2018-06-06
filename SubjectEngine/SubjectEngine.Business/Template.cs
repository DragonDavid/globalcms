using System;
using Framework.Business;
using SubjectEngine.Data;
using Framework.Validation;

namespace SubjectEngine.Business
{
    public class Template : BusinessObject<TemplateData>
    {
        protected override void SetDefaultValues()
        {
            base.SetDefaultValues();

            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        [RequiredField("TemplateNameRequired", "The Name must be defined.")]
        [StringLength("TemplateNameLength", "The Name must have a length less than {1}", MaxLength = 50)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        [StringLength("TemplateSlugLength", "The Slug must have a length less than {1}", MaxLength = 200)]
        public string Slug
        {
            get { return Data.Slug; }
            set { Data.Slug = value; }
        }

        public bool HideTitle
        {
            get { return Data.HideTitle; }
            set { Data.HideTitle = value; }
        }

        public bool EnableReview
        {
            get { return Data.EnableReview; }
            set { Data.EnableReview = value; }
        }

        public bool EnableCategory
        {
            get { return Data.EnableCategory; }
            set { Data.EnableCategory = value; }
        }

        public bool EnableLocation
        {
            get { return Data.EnableLocation; }
            set { Data.EnableLocation = value; }
        }

        public DateTime CreatedDate
        {
            get { return Data.CreatedDate; }
            set { Data.CreatedDate = value; }
        }
        public DateTime ModifiedDate
        {
            get { return Data.ModifiedDate; }
            set { Data.ModifiedDate = value; }
        }
    }
}
