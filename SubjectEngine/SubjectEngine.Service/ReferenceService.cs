using System.Collections.Generic;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using Framework.Service;
using Framework.UoW;
using SubjectEngine.Core;

namespace SubjectEngine.Service
{
    public class ReferenceService : UpdateEntityService<IReferenceRepository, ReferenceData>, IReferenceService
    {
        public IServiceQueryResultList<ReferenceBriefData> GetList(int folderId, int pageIndex, int pageSize)
        {
            IEnumerable<ReferenceBriefData> result = Repository.GetList(folderId, pageIndex, pageSize);
            return ServiceResultFactory.BuildServiceQueryResult<ReferenceBriefData>(result);
        }

        public IServiceQueryResult<ReferenceInfoData> GetReference(object id)
        {
            ReferenceInfoData result = Repository.GetReference(id);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }

        public IServiceQueryResult<ReferenceInfoData> GetReference(string urlAlias)
        {
            ReferenceInfoData result = Repository.GetReference(urlAlias);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }

        public IServiceQueryResult<ReferenceInfoData> GetReference(string urlAlias, object locationId, object languageId)
        {
            ReferenceInfoData result = Repository.GetReference(urlAlias, locationId, languageId);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }

        public IServiceQueryResultList<SubjectInfoData> GetAttachedSubjects(object refId, object subitemId, int pageIndex, int pageSize, object locationId = null, object languageId = null)
        {
            IEnumerable<SubjectInfoData> result = Repository.GetAttachedSubjects(refId, subitemId, pageIndex, pageSize, locationId, languageId);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }

        public IServiceQueryResultList<SubjectInfoData> GetSubjectsByTemplate(object templateId, object categoryId, int pageIndex, int pageSize, object subsiteId = null, object locationId = null, object languageId = null)
        {
            IEnumerable<SubjectInfoData> result = Repository.GetSubjectsByTemplate(templateId, categoryId, pageIndex, pageSize, subsiteId, locationId, languageId);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }

        public IServiceQueryResultList<SubjectInfoData> GetSubjectsByKeyword(object keywordId, object templateId, int pageIndex, int pageSize, object languageId = null)
        {
            IEnumerable<SubjectInfoData> result = Repository.GetSubjectsByKeyword(keywordId, templateId, pageIndex, pageSize, languageId);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }

        public IServiceQueryResultList<SubjectInfoData> GetSubjectsByCategory(object categoryId, object templateId, int pageIndex, int pageSize, object languageId = null)
        {
            IEnumerable<SubjectInfoData> result = Repository.GetSubjectsByCategory(categoryId, templateId, pageIndex, pageSize, languageId);
            return ServiceResultFactory.BuildServiceQueryResult(result);
        }
    }
}