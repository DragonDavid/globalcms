using Framework.Business;
using SubjectEngine.Data;
using Framework.Validation;

namespace SubjectEngine.Business
{
    public class Location : BusinessObject<LocationData>
    {
        [RequiredField("LocationNameRequired", "The Name must be defined.")]
        [StringLength("LocationNameLength", "The Name must have a length less than {1}", MaxLength = 100)]
        public string Name
        {
            get
            {
                return Data.Name;
            }
            set
            {
                Data.Name = value;
            }
        }

        public bool IsPublished
        {
            get { return Data.IsPublished; }
            set { Data.IsPublished = value; }
        }
    }
}
