using System;
using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class ReferenceCategoryInfoData : ChildDataObject
    {
        public virtual CategoryData Category { get; set; }
    }
}
