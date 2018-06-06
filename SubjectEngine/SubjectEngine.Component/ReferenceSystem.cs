using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Business;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class ReferenceSystem : BusinessComponent
    {
        public ReferenceSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> RetrieveAllReference<TDto>(IDataConverter<ReferenceData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto RetrieveOrNewReference<TDto>(object instanceId, IDataConverter<ReferenceData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            Reference instance = RetrieveOrNew<ReferenceData, Reference, IReferenceService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<ReferenceData>());
            }
            else
            {
                return null;
            }
        }

        internal FacadeUpdateResult<ReferenceData> SaveReference(ReferenceData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            Reference instance = RetrieveOrNew<ReferenceData, Reference, IReferenceService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Name = dto.Name;
                instance.Slug = dto.Slug;
                instance.Title = dto.Title;
                instance.ThumbnailUrl = dto.ThumbnailUrl;
                instance.Description = dto.Description;
                instance.TemplateId = dto.TemplateId;
                instance.LocationId = dto.LocationId;
                instance.CreatedById = dto.CreatedById;
                instance.FolderId = dto.FolderId;
                instance.IsMaster = dto.IsMaster;
                instance.IsPublished = dto.IsPublished;
                instance.EnableAds = dto.EnableAds;
                instance.EnableTopAd = dto.EnableTopAd;
                instance.ModifiedDate = DateTime.Now;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ReferenceData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> SaveReferenceBasic(ReferenceData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            Reference instance = RetrieveOrNew<ReferenceData, Reference, IReferenceService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.Slug = dto.Slug;
                instance.Title = dto.Title;
                instance.ThumbnailUrl = dto.ThumbnailUrl;
                instance.Description = dto.Description;
                instance.Keywords = dto.Keywords;
                instance.EnableAds = dto.EnableAds;
                instance.EnableTopAd = dto.EnableTopAd;
                instance.ModifiedDate = DateTime.Now;
                instance.LocationId = dto.LocationId;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ReferenceData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> SaveReferenceLanguageBasic(ReferenceData dto, object languageId)
        {
            ArgumentValidator.IsNotNull("dto", dto);
            ArgumentValidator.IsNotNull("languageId", languageId);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            Reference instance = RetrieveOrNew<ReferenceData, Reference, IReferenceService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.ModifiedDate = DateTime.Now;

                // Check existence of current language 
                ReferenceLanguage referenceLanguage = instance.ReferenceLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, languageId));
                if (referenceLanguage == null)
                {
                    referenceLanguage = instance.ReferenceLanguages.AddNewBo();
                    referenceLanguage.LanguageId = languageId;
                }
                referenceLanguage.Title = dto.Title;
                referenceLanguage.Description = dto.Description;
                referenceLanguage.Keywords = dto.Keywords;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ReferenceData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> SaveReferenceCategorys(object referenceId, IList<ReferenceCategoryData> referenceCategorys)
        {
            ArgumentValidator.IsNotNull("referenceId", referenceId);
            ArgumentValidator.IsNotNull("referenceCategorys", referenceCategorys);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            Reference instance = RetrieveOrNew<ReferenceData, Reference, IReferenceService>(result.ValidationResult, referenceId);

            if (result.IsSuccessful)
            {
                instance.ModifiedDate = DateTime.Now;
                // Remove all existing ReferenceCategorys
                instance.ReferenceCategorys.Clear();
                // Categorys
                foreach (ReferenceCategoryData item in referenceCategorys)
                {
                    ReferenceCategory child = instance.ReferenceCategorys.AddNewBo();
                    child.CategoryId = item.CategoryId;
                }

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ReferenceData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> SaveReferenceKeywords(object referenceId, IList<ReferenceKeywordData> referenceKeywords)
        {
            ArgumentValidator.IsNotNull("referenceId", referenceId);
            ArgumentValidator.IsNotNull("referenceKeywords", referenceKeywords);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            Reference instance = RetrieveOrNew<ReferenceData, Reference, IReferenceService>(result.ValidationResult, referenceId);

            if (result.IsSuccessful)
            {
                instance.ModifiedDate = DateTime.Now;
                // Remove all existing ReferenceKeywords
                instance.ReferenceKeywords.Clear();
                // Keywords
                foreach (ReferenceKeywordData item in referenceKeywords)
                {
                    ReferenceKeyword child = instance.ReferenceKeywords.AddNewBo();
                    child.KeywordId = item.KeywordId;
                    child.Sort = item.Sort;
                }

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ReferenceData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<GridRowData> SaveGridRow(GridRowData row)
        {
            ArgumentValidator.IsNotNull("row", row);

            FacadeUpdateResult<GridRowData> result = new FacadeUpdateResult<GridRowData>();
            IGridRowService service = UnitOfWork.GetService<IGridRowService>();
            GridRow instance = RetrieveOrNew<GridRowData, GridRow, IGridRowService>(result.ValidationResult, row.Id);

            if (result.IsSuccessful)
            {
                // Grid cells
                if (instance.IsNew)
                {
                    instance.ReferenceId = row.ReferenceId;
                    instance.GridId = row.GridId;
                    instance.Sort = row.Sort;

                    // Save row first
                    var saveRowQuery = service.Save(instance);
                    // Then save cells
                    foreach (GridCellData newValue in row.Cells)
                    {
                        GridCell child = instance.Cells.AddNewBo();
                        child.GridColumnId = newValue.GridColumnId;
                        child.ValueText = newValue.ValueText;
                        child.ValueHtml = newValue.ValueHtml;
                        child.ValueInt = newValue.ValueInt;
                        child.ValueDate = newValue.ValueDate;
                        child.ValueUrl = newValue.ValueUrl;
                    }
                }
                else
                {
                    foreach (GridCellData newValue in row.Cells)
                    {
                        GridCell child = instance.Cells.SingleOrDefault(o => object.Equals(o.GridColumnId, newValue.GridColumnId));
                        if (child != null)
                        {
                            child.GridColumnId = newValue.GridColumnId;
                            child.ValueText = newValue.ValueText;
                            child.ValueHtml = newValue.ValueHtml;
                            child.ValueInt = newValue.ValueInt;
                            child.ValueDate = newValue.ValueDate;
                            child.ValueUrl = newValue.ValueUrl;
                        }
                        else
                        {
                            AddError(result.ValidationResult, "GridCellCannotBeFound");
                        }
                    }
                }

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<GridRowData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<GridRowData> DeleteGridRow(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<GridRowData> result = new FacadeUpdateResult<GridRowData>();
            IGridRowService service = UnitOfWork.GetService<IGridRowService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                GridRow instance = query.ToBo<GridRow>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "GridRowCannotBeFound");
            }

            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> SetPublish(object instanceId, bool status)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Reference instance = query.ToBo<Reference>();
                if (instance.IsPublished != status)
                {
                    instance.IsPublished = status;
                    var saveQuery = service.Save(instance);

                    result.AttachResult(instance.RetrieveData<ReferenceData>());
                    result.Merge(saveQuery);
                }
            }
            else
            {
                AddError(result.ValidationResult, "ReferenceCannotBeFound");
            }
            return result;
        }

        internal IFacadeUpdateResult<ReferenceData> DeleteReference(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<ReferenceData> result = new FacadeUpdateResult<ReferenceData>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                Reference instance = query.ToBo<Reference>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "ReferenceCannotBeFound");
            }

            return result;
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (ReferenceData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.Name));
                }
            }

            return dataSource;
        }
    }
}
