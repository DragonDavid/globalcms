
namespace SubjectEngine.Core
{
    public static class BlockRegister
    {
        public static class PhotoGallery
        {
            public const string WidgetName = "PhotoGallery";
            public const int Title = 32;                // Text
            public const int Subtitle = 33;             // Text
            public const int Abstract = 34;             // TextArea
            public const int ThumbnailUrl = 35;         // Image
            public const int PhotosGrid = 36;           // Grid
            public const int RelatedGalleryList = 37;   // ReferenceList
        }

        public static class PhotoList
        {
            public const string WidgetName = "PhotoList";
            public const int Title = 42;                // Text
            public const int PhotosGrid = 43;           // Grid
        }

        public static class Rotator
        {
            public const string WidgetName = "RotatorWidget";
            public const int Title = 19;                    // Text
            public const int RotatorItemCollection = 20;    // ReferenceCollection
        }

        public static class HeroImageBlock
        {
            public const string WidgetName = "HeroImage";
            public const int Image = 3;                 // Image
            public const int Title = 4;                 // Hyperlink
            public const int Description = 5;           // HtamArea
        }

        public static class SubjectDetailBlock
        {
            public const string WidgetName = "SubjectDetail";
            public const int Title = 1;             // Text
            public const int Image = 2;             // Image
            public const int Description = 6;       // HtmlArea
            public const int VideoId = 50;          // Text
        }

        public static class YouTubeVideoBlock
        {
            public const string WidgetName = "YouTubeVideo";
            public const int VideoId = 28;          // Text
            public const int Title = 29;            // Text
            public const int ThumbnailUrl = 30;     // Image
            public const int Description = 49;      // TextArea
        }

        public static class BlogDetail
        {
            public const string WidgetName = "BlogDetail";
            public const int Title = 11;            // Text
            public const int IssuedTime = 12;       // Datetime
            public const int Author = 13;           // Text
            public const int Abstract = 14;         // TextArea
            public const int Image = 15;            // Image
            public const int Content = 16;          // HtmlArea
        }

        public static class ListViewWidget
        {
            public const string WidgetName = "ListViewWidget";
            public const int ReferenceList = 17;    // ReferenceList
            public const int PageSize = 46;         // Integer
        }

        public static class RelatedContent
        {
            public const string WidgetName = "RelatedContent";
            public const int Title = 55;            // Text
        }

        public static class AdWidget
        {
            public const string WidgetName = "AdWidget";
            public const int AdType = 54;            // Text
        }

        public static class FeaturedContent
        {
            public const string WidgetName = "FeaturedContent";
            public const int Title = 10;                    // Text
            public const int FeatureItemCollection = 31;    // ReferenceCollection
        }

        public static class FeaturedContent2nd
        {
            public const string WidgetName = "FeaturedContent2nd";
            public const int Title = 44;                    // Text
            public const int FeatureItemCollection = 45;   // ReferenceCollection
        }

        public static class CardViewWidget
        {
            public const string WidgetName = "CardViewWidget";
            public const int ReferenceList = 18;            // ReferenceList
            public const int PageSize = 47;                 // Integer
        }

        public static class RecipeBlock
        {
            public const string WidgetName = "RecipeDetail";
            public const int Name = 21;                 // Text
            public const int Subtitle = 22;             // Text
            public const int Image = 23;                // Image
            public const int Abstract = 24;             // TextArea
            public const int IngredientGrid = 25;       // Grid
            public const int InstructionGrid = 26;      // Grid
            public const int Tips = 48;                 // HtmlArea
            public const int PrepareTime = 51;          // Integer
            public const int CookTime = 52;             // Integer
            public const int Servings = 53;             // Integer
        }

        public static class CastGroup
        {
            public const int Title = 38;            // Text
            public const int CastGrid = 41;         // Grid
        }

        public static class NoticeGrid
        {
            public const int Col_Title = 1;         // SubTitle
            public const int Col_IssuedTime = 2;    // Datetime
            public const int Col_Notice = 3;        // HtmlArea
        }

        public static class FeatureItemGrid
        {
            public const int Col_Image = 4;         // Image
            public const int Col_Hyperlink = 5;     // Hyperlink
        }

        public static class FeatureItemGrid2nd
        {
            public const int Col_Image = 16;
            public const int Col_Hyperlink = 17;
        }

        public static class PhotoGrid
        {
            public const int Col_Title = 6;         // Text
            public const int Col_Subtitle = 7;      // Text
            public const int Col_Abstract = 8;      // TextArea
            public const int Col_Image = 9;         // Image
        }

        public static class CastGrid
        {
            public const int Col_MemberId = 10;         // Text
            public const int Col_NickName = 11;         // Text
            public const int Col_Gender = 12;           // Text
            public const int Col_Email = 13;            // Text
            public const int Col_DateEnrolled = 14;     // Datetime
            public const int Col_Notes = 15;            // Text
        }

        public static class RotatorItemGrid
        {
            public const int Col_Hyperlink = 18;        // Hyperlink
            public const int Col_Abstract = 19;         // TextArea
            public const int Col_Image = 20;            // Image
        }

        public static class RecipeIngredientGrid
        {
            public const int Col_Sortorder = 21;            // Integer
            public const int Col_IngredientName = 22;       // Text
            public const int Col_Quantity = 23;             // Text
            public const int Col_UnitOfMeasure = 26;        // Text
        }

        public static class RecipeInstructionGrid
        {
            public const int Col_Sortorder = 24;            // Integer
            public const int Col_Description = 25;          // TextArea
        }
    }
}
