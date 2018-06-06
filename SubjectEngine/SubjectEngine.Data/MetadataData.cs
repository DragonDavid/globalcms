using Framework.Data;

namespace SubjectEngine.Data
{
    public class MetadataData : DataObject
    {
        public virtual string MetaType { get; set; }
        public virtual string MetaKey { get; set; }
        public virtual string MetaContent { get; set; }
    }
}
