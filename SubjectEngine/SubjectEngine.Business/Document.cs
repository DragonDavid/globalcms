using System;
using Framework.Business;
using SubjectEngine.Data;
using Framework.Validation;

namespace SubjectEngine.Business
{
    public class Document : BusinessObject<DocumentData>
    {
        protected override void SetDefaultValues()
        {
            base.SetDefaultValues();

            IssuedDate = DateTime.Now;
        }

        [RequiredField("DocumentTitleRequired", "The Title must be defined.")]
        [StringLength("DocumentTitleLength", "The Title must have a length less than {1}", MaxLength = 100)]
        public string Title
        {
            get { return Data.Title; }
            set { Data.Title = value; }
        }

        [StringLength("DocumentFileNameLength", "The FileName must have a length less than {1}", MaxLength = 100)]
        public string FileName
        {
            get { return Data.FileName; }
            set { Data.FileName = value; }
        }

        [StringLength("DocumentContentUriLength", "The ContentUri must have a length less than {1}", MaxLength = 200)]
        public string ContentUri
        {
            get { return Data.ContentUri; }
            set { Data.ContentUri = value; }
        }

        public int DocTypeId
        {
            get { return Data.DocTypeId; }
            set { Data.DocTypeId = value; }
        }

        public object IssuedById
        {
            get { return Data.IssuedById; }
            set { Data.IssuedById = value; }
        }

        public DateTime IssuedDate
        {
            get { return Data.IssuedDate; }
            set { Data.IssuedDate = value; }
        }

        [StringLength("DocumentExtensionLength", "The Extension must have a length less than {1}", MaxLength = 10)]
        public string Extension
        {
            get
            {
                return Data.Extension;
            }
            set
            {
                Data.Extension = value;
            }
        }

        [StringLength("DocumentContentTypeLength", "The ContentType must have a length less than {1}", MaxLength = 100)]
        public string ContentType
        {
            get { return Data.ContentType; }
            set { Data.ContentType = value; }
        }

        public int ContentLength
        {
            get { return Data.ContentLength; }
            set { Data.ContentLength = value; }
        }

    }
}
