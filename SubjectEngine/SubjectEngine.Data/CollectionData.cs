using Framework.Data;
using System;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class CollectionData : DataObject
    {
        public CollectionData()
        {
            CollectionItemsData = new List<CollectionItemData>();
        }

        public virtual string Name { get; set; }
        public virtual object CreatedById { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual IList<CollectionItemData> CollectionItemsData { get; set; }

    }
}
