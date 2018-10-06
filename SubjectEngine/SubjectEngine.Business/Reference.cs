using System.Linq;
using Framework.Business;
using SubjectEngine.Data;
using Framework.Validation;
using System;

namespace SubjectEngine.Business
{
    public class Reference : BusinessObject<ReferenceData>
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            ReferenceCategorys = new ChildBoCollection<ReferenceData, ReferenceCategory, ReferenceCategoryData>
                (Service, Data.ReferenceCategorys, this);
            ReferenceKeywords = new ChildBoCollection<ReferenceData, ReferenceKeyword, ReferenceKeywordData>
                (Service, Data.ReferenceKeywords, this);
            ReferenceLanguages = new ChildBoCollection<ReferenceData, ReferenceLanguage, ReferenceLanguageData>
                (Service, Data.ReferenceLanguages, this);
        }

        protected override void SetDefaultValues()
        {
            base.SetDefaultValues();

            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            EnableAds = true;
            EnableTopAd = true;
        }

        [ChildCollection]
        public ChildBoCollection<ReferenceData, ReferenceLanguage, ReferenceLanguageData> ReferenceLanguages
        {
            get;
            private set;
        }

        [ChildCollection]
        public ChildBoCollection<ReferenceData, ReferenceCategory, ReferenceCategoryData> ReferenceCategorys
        {
            get;
            private set;
        }
        [ChildCollection]
        public ChildBoCollection<ReferenceData, ReferenceKeyword, ReferenceKeywordData> ReferenceKeywords
        {
            get;
            private set;
        }

        [RequiredField("ReferenceTitleRequired", "The Title must be defined.")]
        [StringLength("ReferenceTitleLength", "The Title must have a length less than {1}", MaxLength = 200)]
        public string Title
        {
            get { return Data.Title; }
            set { Data.Title = value; }
        }

        [RequiredField("ReferenceSlugRequired", "The Slug must be defined.")]
        [StringLength("ReferenceSlugLength", "The Slug must have a length less than {1}", MaxLength = 200)]
        public string Slug
        {
            get { return Data.Slug; }
            set { Data.Slug = value; }
        }

        [StringLength("ReferenceNameLength", "The Name must have a length less than {1}", MaxLength = 100)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        [StringLength("ReferenceThumbnailUrlLength", "The ThumbnailUrl must have a length less than {1}", MaxLength = 200)]
        public string ThumbnailUrl
        {
            get { return Data.ThumbnailUrl; }
            set { Data.ThumbnailUrl = value; }
        }

        [StringLength("ReferenceDescriptionLength", "The Description must have a length less than {1}", MaxLength = 1000)]
        public string Description
        {
            get { return Data.Description; }
            set { Data.Description = value; }
        }

        [StringLength("ReferenceKeywordsLength", "The Keywords must have a length less than {1}", MaxLength = 200)]
        public string Keywords
        {
            get { return Data.Keywords; }
            set { Data.Keywords = value; }
        }

        public bool IsPublished
        {
            get { return Data.IsPublished; }
            set { Data.IsPublished = value; }
        }

        public bool IsMaster
        {
            get { return Data.IsMaster; }
            set { Data.IsMaster = value; }
        }

        public bool EnableAds
        {
            get { return Data.EnableAds; }
            set { Data.EnableAds = value; }
        }

        public bool EnableTopAd
        {
            get { return Data.EnableTopAd; }
            set { Data.EnableTopAd = value; }
        }

        public object FolderId
        {
            get { return Data.FolderId; }
            set { Data.FolderId = value; }
        }

        public object TemplateId
        {
            get { return Data.TemplateId; }
            set { Data.TemplateId = value; }
        }

        public object LocationId
        {
            get { return Data.LocationId; }
            set { Data.LocationId = value; }
        }

        public object CreatedById
        {
            get { return Data.CreatedById; }
            set { Data.CreatedById = value; }
        }

        public DateTime CreatedDate
        {
            get { return Data.CreatedDate; }
            set { Data.CreatedDate = value; }
        }

        public DateTime ModifiedDate
        {
            get { return Data.ModifiedDate; }
            set { Data.ModifiedDate = value; }
        }
    }
}
