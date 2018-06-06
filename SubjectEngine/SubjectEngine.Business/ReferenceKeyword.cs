using System;
using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class ReferenceKeyword : ChildBusinessObject<Reference, ReferenceKeywordData>
    {
        public object KeywordId
        {
            get { return Data.KeywordId; }
            set { Data.KeywordId = value; }
        }

        public int Sort
        {
            get { return Data.Sort; }
            set { Data.Sort = value; }
        }
    }
}
