using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class GridData : DataObject
    {
        public virtual string Name { get; set; }
        public virtual ViewMode ViewMode { get; set; }
        public virtual IList<GridColumnData> Columns { get; set; }
    }
}
