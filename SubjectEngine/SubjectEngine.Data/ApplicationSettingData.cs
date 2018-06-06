using Framework.Data;

namespace SubjectEngine.Data
{
    public class ApplicationSettingData : DataObject
    {
        public ApplicationSettingData()
        {
        }

        public virtual string SettingKey { get; set; }
        public virtual string SettingValue { get; set; }
    }
}
