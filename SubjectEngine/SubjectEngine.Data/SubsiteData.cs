using Framework.Data;

namespace SubjectEngine.Data
{
    public class SubsiteData : DataObject
    {
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Website { get; set; }
        public virtual string BackColor { get; set; }
        public virtual string TitleColor { get; set; }
        public virtual string BannerUrl { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual object SubsiteFolderId { get; set; }
        public virtual object DefaultLanguageId { get; set; }
        public virtual object DefaultLocationId { get; set; }
        public virtual int BannerHeight { get; set; }
    }
}
