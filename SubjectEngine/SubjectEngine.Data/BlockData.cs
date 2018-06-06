using System.Collections.Generic;
using Framework.Data;
using System;

namespace SubjectEngine.Data
{
    public class BlockData : DataObject
    {
        public BlockData()
        {
            Subitems = new List<SubitemData>();
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsBuiltIn { get; set; }
        public virtual string WidgetName { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual IList<SubitemData> Subitems { get; set; }
    }
}
