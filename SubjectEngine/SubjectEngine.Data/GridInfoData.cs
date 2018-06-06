using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class GridInfoData : DataObject
    {
        public virtual string Name { get; set; }
        public virtual ViewMode ViewMode { get; set; }
        public virtual IList<GridColumnInfoData> Columns { get; set; }
    }
}
