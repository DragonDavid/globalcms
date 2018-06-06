using System;
using Framework.Data;
using SubjectEngine.Core;

namespace SubjectEngine.Data
{
    public class ReferenceKeywordData : ChildDataObject
    {
        public virtual object KeywordId { get; set; }
        public virtual int Sort { get; set; }
    }
}
