using System;
using Framework.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class SubitemValueData : DataObject
    {
        public SubitemValueData()
        {
            SubitemValueLanguages = new List<SubitemValueLanguageData>();
        }

        public virtual object ReferenceId { get; set; }
        public virtual object SubitemId { get; set; }
        public virtual string ValueText { get; set; }
        public virtual string ValueHtml { get; set; }
        public virtual int? ValueInt { get; set; }
        public virtual DateTime? ValueDate { get; set; }
        public virtual string ValueUrl { get; set; }
        public virtual IList<SubitemValueLanguageData> SubitemValueLanguages { get; set; }
    }
}
