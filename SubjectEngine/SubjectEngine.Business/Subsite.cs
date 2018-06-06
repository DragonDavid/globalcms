using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class Subsite : BusinessObject<SubsiteData>
    {
        [StringLength("SubsiteAddressLength", "The Address must have a length less than {1}", MaxLength = 200)]
        public string Address
        {
            get { return Data.Address; }
            set { Data.Address = value; }
        }

        [StringLength("SubsitePhoneLength", "The Phone must have a length less than {1}", MaxLength = 50)]
        public string Phone
        {
            get { return Data.Phone; }
            set { Data.Phone = value; }
        }

        [StringLength("SubsiteFaxLength", "The Fax must have a length less than {1}", MaxLength = 50)]
        public string Fax
        {
            get { return Data.Fax; }
            set { Data.Fax = value; }
        }

        [StringLength("SubsiteEmailLength", "The Email must have a length less than {1}", MaxLength = 100)]
        public string Email
        {
            get { return Data.Email; }
            set { Data.Email = value; }
        }

        [StringLength("SubsiteWebsiteLength", "The Website must have a length less than {1}", MaxLength = 100)]
        public string Website
        {
            get { return Data.Website; }
            set { Data.Website = value; }
        }

        [StringLength("SubsiteBackColorLength", "The BackColor must have a length less than {1}", MaxLength = 10)]
        public string BackColor
        {
            get { return Data.BackColor; }
            set { Data.BackColor = value; }
        }

        [StringLength("SubsiteTitleColorLength", "The TitleColor must have a length less than {1}", MaxLength = 10)]
        public string TitleColor
        {
            get { return Data.TitleColor; }
            set { Data.TitleColor = value; }
        }

        [StringLength("SubsiteBannerUrlLength", "The BannerUrl must have a length less than {1}", MaxLength = 200)]
        public string BannerUrl
        {
            get { return Data.BannerUrl; }
            set { Data.BannerUrl = value; }
        }

        public bool IsPublished
        {
            get { return Data.IsPublished; }
            set { Data.IsPublished = value; }
        }

        public object SubsiteFolderId
        {
            get { return Data.SubsiteFolderId; }
            set { Data.SubsiteFolderId = value; }
        }

        public object DefaultLanguageId
        {
            get { return Data.DefaultLanguageId; }
            set { Data.DefaultLanguageId = value; }
        }

        public object DefaultLocationId
        {
            get { return Data.DefaultLocationId; }
            set { Data.DefaultLocationId = value; }
        }

        public int BannerHeight
        {
            get { return Data.BannerHeight; }
            set { Data.BannerHeight = value; }
        }
    }
}
