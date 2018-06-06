using System;
using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class GridCell : ChildBusinessObject<GridRow, GridCellData>
    {
        public object GridColumnId
        {
            get { return Data.GridColumnId; }
            set { Data.GridColumnId = value; }
        }

        [StringLength("GridCellValueTextLength", "The Text must have a length less than {1}", MaxLength = 3000)]
        public string ValueText
        {
            get { return Data.ValueText; }
            set { Data.ValueText = value; }
        }

        public string ValueHtml
        {
            get { return Data.ValueHtml; }
            set { Data.ValueHtml = value; }
        }

        public int? ValueInt
        {
            get { return Data.ValueInt; }
            set { Data.ValueInt = value; }
        }
        public DateTime? ValueDate
        {
            get { return Data.ValueDate; }
            set { Data.ValueDate = value; }
        }
        public string ValueUrl
        {
            get { return Data.ValueUrl; }
            set { Data.ValueUrl = value; }
        }
    }
}
