using Framework.Service;
using Framework.UoW;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace SubjectEngine.Service.Contract
{
    public interface IReferenceService : IUpdateEntityService<ReferenceData>
    {
        IServiceQueryResultList<ReferenceBriefData> GetList(int folderId, int pageIndex, int pageSize);
        IServiceQueryResult<ReferenceInfoData> GetReference(object id);
        IServiceQueryResult<ReferenceInfoData> GetReference(string urlAlias);
        IServiceQueryResult<ReferenceInfoData> GetReference(string urlAlias, object locationId, object languageId);
        IServiceQueryResultList<SubjectInfoData> GetAttachedSubjects(object refId, object subitemId, int pageIndex, int pageSize, object locationId = null, object languageId = null);
        IServiceQueryResultList<SubjectInfoData> GetSubjectsByTemplate(object templateId, object categoryId, int pageIndex, int pageSize, object subsiteId = null, object locationId = null, object languageId = null);
        IServiceQueryResultList<SubjectInfoData> GetSubjectsByKeyword(object keywordId, object templateId, int pageIndex, int pageSize, object languageId = null);
        IServiceQueryResultList<SubjectInfoData> GetSubjectsByCategory(object categoryId, object templateId, int pageIndex, int pageSize, object languageId = null);
    }
}
