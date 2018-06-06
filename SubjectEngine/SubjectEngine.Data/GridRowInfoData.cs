using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class GridRowInfoData : ChildDataObject
    {
        public virtual object GridId { get; set; }
        public virtual int Sort { get; set; }
        public virtual IList<GridCellInfoData> Cells { get; set; }
    }
}
