using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class ReviewFacade : BusinessComponent
    {
        public ReviewFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            ReviewSystem = new ReviewSystem(unitOfWork);
        }

        private ReviewSystem ReviewSystem { get; set; }

        public List<TDto> RetrieveAllReview<TDto>(IDataConverter<ReviewData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = ReviewSystem.RetrieveAllReview(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public List<TDto> RetrieveReviewsByReference<TDto>(object productId, IDataConverter<ReviewData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = ReviewSystem.RetrieveReviewsByReference(productId, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public IFacadeUpdateResult<ReviewData> SaveReview(ReviewData dto, object refId)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReviewData> result = ReviewSystem.SaveReview(dto, refId);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }
            return result;
        }

        public IFacadeUpdateResult<ReviewData> DeleteReview(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReviewData> result = ReviewSystem.DeleteReview(id);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }
            return result;
        }
    }
}
