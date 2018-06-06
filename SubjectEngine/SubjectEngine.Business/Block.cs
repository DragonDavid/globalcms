using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;
using System;

namespace SubjectEngine.Business
{
    public class Block : BusinessObject<BlockData>
    {
        protected override void SetDefaultValues()
        {
            base.SetDefaultValues();

            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        [RequiredField("BlockNameRequired", "The Name must be defined.")]
        [StringLength("BlockNameLength", "The Name must have a length less than {1}", MaxLength = 100)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        [StringLength("BlockDescriptionLength", "The Description must have a length less than {1}", MaxLength = 300)]
        public string Description
        {
            get { return Data.Description; }
            set { Data.Description = value; }
        }

        public bool IsBuiltIn
        {
            get { return Data.IsBuiltIn; }
            set { Data.IsBuiltIn = value; }
        }

        [StringLength("BlockWidgetNameLength", "The WidgetName must have a length less than {1}", MaxLength = 50)]
        public string WidgetName
        {
            get { return Data.WidgetName; }
            set { Data.WidgetName = value; }
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
