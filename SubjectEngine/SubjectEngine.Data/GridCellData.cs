using Framework.Data;
using System;

namespace SubjectEngine.Data
{
    public class GridCellData : ChildDataObject
    {
        public virtual object GridColumnId { get; set; }
        public virtual string ValueText { get; set; }
        public virtual string ValueHtml { get; set; }
        public virtual int? ValueInt { get; set; }
        public virtual DateTime? ValueDate { get; set; }
        public virtual string ValueUrl { get; set; }
    }
}
