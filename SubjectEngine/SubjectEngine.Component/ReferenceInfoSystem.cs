using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;
using SubjectEngine.Core;

namespace SubjectEngine.Component
{
    internal class ReferenceInfoSystem : BusinessComponent
    {
        public ReferenceInfoSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal List<TDto> GetList<TDto>(int folderId, int pageIndex, int pageSize, IDataConverter<ReferenceBriefData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetList(folderId, pageIndex, pageSize);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal TDto GetReferenceInfo<TDto>(object id, IDataConverter<ReferenceInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetReference(id);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }
            return null;
        }

        internal TDto GetReferenceInfo<TDto>(string urlAlias, IDataConverter<ReferenceInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetReference(urlAlias);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }
            return null;
        }

        internal TDto GetReferenceInfo<TDto>(string urlAlias, object locationId, object languageId, IDataConverter<ReferenceInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetReference(urlAlias, locationId, languageId);
            if (query.HasResult)
            {
                return query.DataToDto(converter);
            }
            return null;
        }

        internal List<TDto> GetAttachedSubjects<TDto>(object refId, object subitemId, int pageIndex, int pageSize, object locationId, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetAttachedSubjects(refId, subitemId, pageIndex, pageSize, locationId, languageId);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> GetSubjectsByTemplate<TDto>(object templateId, object categoryId, int pageIndex, int pageSize, object subsiteId, object locationId, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetSubjectsByTemplate(templateId, categoryId, pageIndex, pageSize, subsiteId, locationId, languageId);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> GetSubjectsByKeyword<TDto>(object keywordId, object templateId, int pageIndex, int pageSize, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetSubjectsByKeyword(keywordId, templateId, pageIndex, pageSize, languageId);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }

        internal List<TDto> GetSubjectsByCategory<TDto>(object categoryId, object templateId, int pageIndex, int pageSize, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();
            var query = service.GetSubjectsByCategory(categoryId, templateId, pageIndex, pageSize, languageId);
            if (query.HasResult)
            {
                return query.DataToDtoList(converter).ToList();
            }

            return null;
        }
    }
}
