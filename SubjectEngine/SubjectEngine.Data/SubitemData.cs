using System;
using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class SubitemData : ChildDataObject
    {
        public virtual string ItemKey { get; set; }
        public virtual string ItemLabel { get; set; }
        public virtual string DefaultValue { get; set; }
        public virtual bool IsMetaProvider { get; set; }
        public virtual int DataTypeId { get; set; }
        public virtual object GridId { get; set; }
    }
}
