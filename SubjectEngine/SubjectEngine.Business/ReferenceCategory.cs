using System;
using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class ReferenceCategory : ChildBusinessObject<Reference, ReferenceCategoryData>
    {
        public object CategoryId
        {
            get { return Data.CategoryId; }
            set { Data.CategoryId = value; }
        }
    }
}
