using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class GridColumnData : ChildDataObject
    {
        public virtual string ColumnName { get; set; }
        public virtual int ColumnWidth { get; set; }
        public virtual DucTypes ColumnType { get; set; }
        public virtual bool IsHidden { get; set; }
    }
}
