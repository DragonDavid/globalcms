using Framework.Data;

namespace SubjectEngine.Data
{
    public class CollectionItemData : ChildDataObject
    {
        public CollectionItemData()
        {
        }

        public virtual object ReferenceId { get; set; }
        public virtual int Sort { get; set; }
    }
}
