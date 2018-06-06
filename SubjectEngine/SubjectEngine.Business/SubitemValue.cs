using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;
using System;

namespace SubjectEngine.Business
{
    public class SubitemValue : BusinessObject<SubitemValueData>
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            SubitemValueLanguages = new ChildBoCollection<SubitemValueData, SubitemValueLanguage, SubitemValueLanguageData>
                (Service, Data.SubitemValueLanguages, this);
        }

        [ChildCollection]
        public ChildBoCollection<SubitemValueData, SubitemValueLanguage, SubitemValueLanguageData> SubitemValueLanguages
        {
            get;
            private set;
        }

        public object ReferenceId
        {
            get { return Data.ReferenceId; }
            set { Data.ReferenceId = value; }
        }

        public object SubitemId
        {
            get { return Data.SubitemId; }
            set { Data.SubitemId = value; }
        }

        [StringLength("SubitemValueValueTextLength", "The Text must have a length less than {1}", MaxLength = 3000)]
        public string ValueText
        {
            get { return Data.ValueText; }
            set { Data.ValueText = value; }
        }

        public string ValueHtml
        {
            get { return Data.ValueHtml; }
            set { Data.ValueHtml = value; }
        }

        public int? ValueInt
        {
            get { return Data.ValueInt; }
            set { Data.ValueInt = value; }
        }
        public DateTime? ValueDate
        {
            get { return Data.ValueDate; }
            set { Data.ValueDate = value; }
        }
        public string ValueUrl
        {
            get { return Data.ValueUrl; }
            set { Data.ValueUrl = value; }
        }
    }
}
