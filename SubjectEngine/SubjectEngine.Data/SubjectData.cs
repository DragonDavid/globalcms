using System.Collections.Generic;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class SubjectData : DataObject
    {
        public SubjectData()
        {
            SubjectFieldsData = new List<SubjectFieldData>();
        }

        public virtual object MasterSubjectId { get; set; }
        public virtual string SubjectType { get; set; }
        public virtual string SubjectLabel { get; set; }
        public virtual string SubjectIdField { get; set; }
        public virtual string MasterSubjectIdField { get; set; }
        public virtual string Description { get; set; }
        public virtual string TableName { get; set; }
        public virtual string ManageUrl { get; set; }
        public virtual string EditUrl { get; set; }
        public virtual string ListUrl { get; set; }
        public virtual string ImportUrl { get; set; }
        public virtual bool AllowListImport { get; set; }
        public virtual bool AllowListFiltering { get; set; }
        public virtual bool IsAddInGrid { get; set; }
        public virtual bool IsGridInFormEdit { get; set; }
        public virtual bool AllowListAdd { get; set; }
        public virtual bool AllowListEdit { get; set; }
        public virtual bool AllowListDelete { get; set; }

        public virtual IList<SubjectFieldData> SubjectFieldsData { get; set; }
    }
}
