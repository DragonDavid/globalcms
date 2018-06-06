using System.Collections.Generic;
using Framework.Data;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace SubjectEngine.Repository.Contract
{
    public interface IReferenceRepository : IUpdateEntityRepository<ReferenceData>
    {
        IEnumerable<ReferenceBriefData> GetList(int folderId, int pageIndex, int pageSize);
        ReferenceInfoData GetReference(object id);
        ReferenceInfoData GetReference(string urlAlias);
        ReferenceInfoData GetReference(string urlAlias, object locationId, object languageId);
        IEnumerable<SubjectInfoData> GetAttachedSubjects(object refId, object subitemId, int pageIndex, int pageSize, object locationId = null, object languageId = null);
        IEnumerable<SubjectInfoData> GetSubjectsByTemplate(object templateId, object categoryId, int pageIndex, int pageSize, object subsiteId = null, object locationId = null, object languageId = null);
        IEnumerable<SubjectInfoData> GetSubjectsByKeyword(object keywordId, object templateId, int pageIndex, int pageSize, object languageId = null);
        IEnumerable<SubjectInfoData> GetSubjectsByCategory(object categoryId, object templateId, int pageIndex, int pageSize, object languageId = null);
    }
}
