using System.Collections.Generic;
using Framework.Data;

namespace SubjectEngine.Data
{
    public class ZoneInfoData : ChildDataObject
    {
        public virtual string Label { get; set; }
        public virtual bool ShowLabel { get; set; }
        public virtual int Row { get; set; }
        public virtual int Col { get; set; }
        public virtual string Style { get; set; }
        public virtual BlockInfoData Block { get; set; }
    }
}
