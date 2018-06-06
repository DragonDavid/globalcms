using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    /// <summary>
    /// Summary description for EntityValue.
    /// </summary>
    public class CollectionItem : ChildBusinessObject<Collection, CollectionItemData>
    {
        public object ReferenceId
        {
            get { return Data.ReferenceId; }
            set { Data.ReferenceId = value; }
        }

        public int Sort
        {
            get { return Data.Sort; }
            set { Data.Sort = value; }
        }
    }
}
