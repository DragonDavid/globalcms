using System;
using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class GridRow : BusinessObject<GridRowData>
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            Cells = new ChildBoCollection<GridRowData, GridCell, GridCellData>
                (Service, Data.Cells, this);
        }

        [ChildCollection]
        public ChildBoCollection<GridRowData, GridCell, GridCellData> Cells
        {
            get;
            private set;
        }

        public object ReferenceId
        {
            get { return Data.ReferenceId; }
            set { Data.ReferenceId = value; }
        }

        public object GridId
        {
            get { return Data.GridId; }
            set { Data.GridId = value; }
        }

        public int? Sort
        {
            get { return Data.Sort; }
            set { Data.Sort = value; }
        }
    }
}
