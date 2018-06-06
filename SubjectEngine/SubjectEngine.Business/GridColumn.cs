using System;
using Framework.Business;
using Framework.Validation;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class GridColumn : ChildBusinessObject<Grid, GridColumnData>
    {
        public string ColumnName
        {
            get { return Data.ColumnName; }
            set { Data.ColumnName = value; }
        }

        public int ColumnWidth
        {
            get { return Data.ColumnWidth; }
            set { Data.ColumnWidth = value; }
        }

        public DucTypes ColumnType
        {
            get { return Data.ColumnType; }
            set { Data.ColumnType = value; }
        }

        public bool IsHidden
        {
            get { return Data.IsHidden; }
            set { Data.IsHidden = value; }
        }
    }
}
