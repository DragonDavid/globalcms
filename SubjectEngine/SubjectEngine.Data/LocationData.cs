using Framework.Data;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class LocationData : DataObject
    {
        public LocationData()
        {
            LocationLanguages = new List<LocationLanguageData>();
        }

        public virtual string Name { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual IList<LocationLanguageData> LocationLanguages { get; set; }
    }
}
