using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class Subitem : ChildBusinessObject<Block, SubitemData>
    {
        [StringLength("SubitemItemKeyLength", "The ItemKey must have a length less than {1}", MaxLength = 100)]
        public string ItemKey
        {
            get { return Data.ItemKey; }
            set { Data.ItemKey = value; }
        }
        [StringLength("SubitemItemLabelLength", "The ItemLabel must have a length less than {1}", MaxLength = 100)]
        public string ItemLabel
        {
            get { return Data.ItemLabel; }
            set { Data.ItemLabel = value; }
        }

        public string DefaultValue
        {
            get { return Data.DefaultValue; }
            set { Data.DefaultValue = value; }
        }

        public bool IsMetaProvider
        {
            get { return Data.IsMetaProvider; }
            set { Data.IsMetaProvider = value; }
        }

        public int DataTypeId
        {
            get { return Data.DataTypeId; }
            set { Data.DataTypeId = value; }
        }

        public object GridId
        {
            get { return Data.GridId; }
            set { Data.GridId = value; }
        }
    }
}
