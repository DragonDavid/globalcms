using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class ReferenceFacade : BusinessComponent
    {
        public ReferenceFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            ReferenceSystem = new ReferenceSystem(unitOfWork);
        }

        private ReferenceSystem ReferenceSystem { get; set; }

        public List<TDto> RetrieveAllReference<TDto>(IDataConverter<ReferenceData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = ReferenceSystem.RetrieveAllReference(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public TDto RetrieveOrNewReference<TDto>(object instanceId, IDataConverter<ReferenceData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = ReferenceSystem.RetrieveOrNewReference(instanceId, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public IFacadeUpdateResult<ReferenceData> SaveReference(ReferenceData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.SaveReference(dto);
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

        public IFacadeUpdateResult<ReferenceData> SaveReferenceInWhole(ReferenceData dto)
        {
            UnitOfWork.BeginTransaction();
            // 1. Save Reference itself
            FacadeUpdateResult<ReferenceData> result = ReferenceSystem.SaveReference(dto);
            if (result.IsSuccessful)
            {
                object referenceId = result.Result.Id;
                // 2. Save ReferenceKeywords
                IFacadeUpdateResult<ReferenceData> result2 = ReferenceSystem.SaveReferenceKeywords(referenceId, dto.ReferenceKeywords);
                if (result2.IsSuccessful)
                {
                    // 3. Save SubitemValues
                    SubitemValueSystem subitemValueSystem = new SubitemValueSystem(UnitOfWork);
                    IFacadeUpdateResult<ReferenceData> result3 = subitemValueSystem.SaveSubitemValues(referenceId, dto.Values);
                    if (result3.IsSuccessful)
                    {
                        foreach (GridRowData row in dto.GridRows)
                        {
                            row.ReferenceId = referenceId;
                            IFacadeUpdateResult<GridRowData> result4 = ReferenceSystem.SaveGridRow(row);
                            if (!result4.IsSuccessful)
                            {
                                result.ValidationResult.Merge(result4.ValidationResult);
                            }
                        }
                    }
                    else
                    {
                        result.ValidationResult.Merge(result3.ValidationResult);
                    }
                }
                else
                {
                    result.ValidationResult.Merge(result2.ValidationResult);
                }
            }
            // Commit or Rollback
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

        /// <summary>
        /// Update Slug, Title, Description, EnableAds, EnableTopAd, ModifiedDate
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IFacadeUpdateResult<ReferenceData> SaveReferenceBasic(ReferenceData dto)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.SaveReferenceBasic(dto);
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

        public IFacadeUpdateResult<ReferenceData> SaveReferenceLanguageBasic(ReferenceData dto, object languageId)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.SaveReferenceLanguageBasic(dto, languageId);
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

        /// <summary>
        /// Update ReferenceCategorys, ModifiedDate
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IFacadeUpdateResult<ReferenceData> SaveReferenceCategorys(object referenceId, IList<ReferenceCategoryData> referenceCategorys)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.SaveReferenceCategorys(referenceId, referenceCategorys);
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

        public IFacadeUpdateResult<ReferenceData> SaveReferenceCategorysInBatch(IList<ReferenceData> references)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = null;
            foreach (ReferenceData item in references)
            {
                result = ReferenceSystem.SaveReferenceCategorys(item.Id, item.ReferenceCategorys);
                if (!result.IsSuccessful)
                {
                    break;
                }
                // TODO: result need to be merged later
            }
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

        public IFacadeUpdateResult<ReferenceData> SaveReferenceKeywords(object referenceId, IList<ReferenceKeywordData> referenceKeywords)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.SaveReferenceKeywords(referenceId, referenceKeywords);
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

        /// <summary>
        /// Update Values, ModifiedDate
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IFacadeUpdateResult<ReferenceData> SaveReferenceValues(object referenceId, IList<SubitemValueData> values)
        {
            SubitemValueSystem subitemValueSystem = new SubitemValueSystem(UnitOfWork);

            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = subitemValueSystem.SaveSubitemValues(referenceId, values);
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

        public IFacadeUpdateResult<ReferenceData> SaveReferenceValueLanguages(IList<SubitemValueData> values, object languageId)
        {
            SubitemValueSystem subitemValueSystem = new SubitemValueSystem(UnitOfWork);

            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = subitemValueSystem.SaveSubitemValueLanguages(values, languageId);
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

        /// <summary>
        /// Update GridRows and their GridCells
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public IFacadeUpdateResult<GridRowData> SaveGridRow(GridRowData row)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<GridRowData> result = ReferenceSystem.SaveGridRow(row);
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

        public bool SetPublish(object instanceId, bool status)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.SetPublish(instanceId, status);
            if (result.IsSuccessful)
            {
                UnitOfWork.CommitTransaction();
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }

            return result.IsSuccessful;
        }

        public IFacadeUpdateResult<ReferenceData> DeleteReference(object id)
        {
            UnitOfWork.BeginTransaction();
            IFacadeUpdateResult<ReferenceData> result = ReferenceSystem.DeleteReference(id);
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

        public IList<BindingListItem> GetBindingList()
        {
            return ReferenceSystem.GetBindingList();
        }
    }
}
