using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class ReferenceInfoFacade : BusinessComponent
    {
        public ReferenceInfoFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            ReferenceSystem = new ReferenceInfoSystem(unitOfWork);
        }

        private ReferenceInfoSystem ReferenceSystem { get; set; }

        public List<TDto> GetList<TDto>(int folderId, int pageIndex, int pageSize, IDataConverter<ReferenceBriefData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = ReferenceSystem.GetList(folderId, pageIndex, pageSize, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public TDto GetReferenceInfo<TDto>(object id, IDataConverter<ReferenceInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = ReferenceSystem.GetReferenceInfo(id, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public TDto GetReferenceInfo<TDto>(string urlAlias, IDataConverter<ReferenceInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = ReferenceSystem.GetReferenceInfo(urlAlias, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public TDto GetReferenceInfo<TDto>(string urlAlias, object locationId, object languageId, IDataConverter<ReferenceInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            TDto result = ReferenceSystem.GetReferenceInfo(urlAlias, locationId, languageId, converter);
            UnitOfWork.CommitTransaction();
            return result;
        }

        public List<TDto> GetAttachedSubjects<TDto>(object refId, object subitemId, int pageIndex, int pageSize, object locationId, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = ReferenceSystem.GetAttachedSubjects(refId, subitemId, pageIndex, pageSize, locationId, languageId, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public List<TDto> GetSubjectsByTemplate<TDto>(object templateId, object categoryId, int pageIndex, int pageSize, object subsiteId, object locationId, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = ReferenceSystem.GetSubjectsByTemplate(templateId, categoryId, pageIndex, pageSize, subsiteId, locationId, languageId, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public List<TDto> GetSubjectsByKeyword<TDto>(object keywordId, object templateId, int pageIndex, int pageSize, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = ReferenceSystem.GetSubjectsByKeyword(keywordId, templateId, pageIndex, pageSize, languageId, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public List<TDto> GetSubjectsByCategory<TDto>(object categoryId, object templateId, int pageIndex, int pageSize, object languageId, IDataConverter<SubjectInfoData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            List<TDto> instances = ReferenceSystem.GetSubjectsByCategory(categoryId, templateId, pageIndex, pageSize, languageId, converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            UnitOfWork.CommitTransaction();
            return instances;
        }
    }
}
