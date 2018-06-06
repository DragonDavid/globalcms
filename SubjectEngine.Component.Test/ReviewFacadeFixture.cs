using Framework.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class ReviewFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            ReviewFacade facade = new ReviewFacade(UnitOfWork);
            List<ReviewDto> result = facade.RetrieveAllReview(new ReviewConverter());
            if (result != null)
            {
            }
            List<ReviewDto> result2 = facade.RetrieveReviewsByReference(0, new ReviewConverter());
            if (result2 != null)
            {
            }
        }

        [TestMethod]
        public void SaveReview()
        {
            // Mock data
            ReviewDto dto = new ReviewDto();
            dto.Title = "test1";
            dto.Content = "review 1 content";
            dto.IssuedBy = "david";
            dto.IssuedByEmail = "david@test.com";
            dto.IsPublished = true;

            ReviewData data = ReviewConverter.ConvertToData(dto);
            ReviewFacade facade = new ReviewFacade(UnitOfWork);
            IFacadeUpdateResult<ReviewData> result = facade.SaveReview(data, 0);
            if (result.IsSuccessful)
            {
            }
        }
    }
}
