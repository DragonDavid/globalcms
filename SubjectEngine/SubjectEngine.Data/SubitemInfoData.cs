using System;
using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class SubitemInfoData : ChildDataObject
    {
        public virtual string ItemKey { get; set; }
        public virtual string ItemLabel { get; set; }
        public virtual string DefaultValue { get; set; }
        public virtual bool IsMetaProvider { get; set; }
        public virtual DucTypes DucType { get; set; }
        public virtual GridInfoData Grid { get; set; }
    }
}
