using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectEngine.Core
{
    public class ApplicationOption
    {
        public ApplicationOption()
        {
            Name = "cms";
            EnableAds = false;
            IsTestMode = false;
            EnableSSL = false;
            EnableTracking = false;
            IsMultiLanguageSupported = false;
            DefaultLanguageId = 1;
            EnableReview = false;
            EnableNotification = false;
            NoticeContentBriefLength = 100;
            DateFormatString = "{0: yyyy-MMM-dd}";
            DateTimeFormatString = "{0: yyyy-MMM-dd HH:mm}";
            ImageServeRoot = "";
            BaseDirectory = "/";
            DefaultLocationId = 1;
        }

        public string Name { get; set; }
        public bool EnableAds { get; set; }
        public bool IsTestMode { get; set; }
        public bool EnableSSL { get; set; }
        public bool EnableTracking { get; set; }
        public bool IsMultiLanguageSupported { get; set; }
        public object DefaultLanguageId { get; set; }
        public bool EnableReview { get; set; }
        public bool EnableNotification { get; set; }
        public int NoticeContentBriefLength { get; set; }
        public string DateTimeFormatString { get; set; }
        public string DateFormatString { get; set; }
        public string ImageServeRoot { get; set; }
        public string BaseDirectory { get; set; }
        public bool IsMultiLocationSupported { get; set; }
        public object DefaultLocationId { get; set; }
    }
}
