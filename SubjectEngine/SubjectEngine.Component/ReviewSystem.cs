using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Business;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class ReviewSystem : BusinessComponent
    {
        public ReviewSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> RetrieveAllReview<TDto>(IDataConverter<ReviewData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IReviewService service = UnitOfWork.GetService<IReviewService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> RetrieveReviewsByReference<TDto>(object id, IDataConverter<ReviewData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("productId", id);
            ArgumentValidator.IsNotNull("converter", converter);

            IReviewService service = UnitOfWork.GetService<IReviewService>();
            var query = service.SearchByReference(id);

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal IFacadeUpdateResult<ReviewData> SaveReview(ReviewData dto, object refId)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<ReviewData> result = new FacadeUpdateResult<ReviewData>();
            IReviewService service = UnitOfWork.GetService<IReviewService>();
            Review instance = RetrieveOrNew<ReviewData, Review, IReviewService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.ReferenceId = refId;
                instance.Title = dto.Title;
                instance.Content = dto.Content;
                instance.IssuedBy = dto.IssuedBy;
                instance.IssuedByEmail = dto.IssuedByEmail;
                instance.IsPublished = dto.IsPublished;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ReviewData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<ReviewData> DeleteReview(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<ReviewData> result = new FacadeUpdateResult<ReviewData>();
            IReviewService service = UnitOfWork.GetService<IReviewService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Review instance = query.ToBo<Review>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "ReviewCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            IReviewService service = UnitOfWork.GetService<IReviewService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (ReviewData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Title));
                }
            }

            return dataSource;
        }
    }
}
