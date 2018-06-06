using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;
using System;

namespace SubjectEngine.Business
{
    public class Review : BusinessObject<ReviewData>
    {
        protected override void SetDefaultValues()
        {
            base.SetDefaultValues();

            IssuedTime = DateTime.Now;
        }

        public object ReferenceId
        {
            get { return Data.ReferenceId; }
            set { Data.ReferenceId = value; }
        }

        public decimal? Rating
        {
            get { return Data.Rating; }
            set { Data.Rating = value; }
        }

        [RequiredField("ReviewContentRequired", "The Content must be defined.")]
        [StringLength("ReviewContentLength", "The Content must have a length less than {1}", MaxLength = 1999)]
        public string Content
        {
            get { return Data.Content; }
            set { Data.Content = value; }
        }

        [StringLength("ReviewTitleLength", "The Title must have a length less than {1}", MaxLength = 100)]
        public string Title
        {
            get { return Data.Title; }
            set { Data.Title = value; }
        }

        public string IssuedBy
        {
            get { return Data.IssuedBy; }
            set { Data.IssuedBy = value; }
        }

        public string IssuedByEmail
        {
            get { return Data.IssuedByEmail; }
            set { Data.IssuedByEmail = value; }
        }

        public DateTime IssuedTime
        {
            get { return Data.IssuedTime; }
            set { Data.IssuedTime = value; }
        }

        public bool IsPublished
        {
            get { return Data.IsPublished; }
            set { Data.IsPublished = value; }
        }
    }
}
