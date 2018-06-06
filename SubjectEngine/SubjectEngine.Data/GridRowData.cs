using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class GridRowData : DataObject
    {
        public GridRowData()
        {
            Cells = new List<GridCellData>();
        }

        public virtual object ReferenceId { get; set; }
        public virtual object GridId { get; set; }
        public virtual int? Sort { get; set; }
        public virtual IList<GridCellData> Cells { get; set; }
    }
}
