using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core;
using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Core;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class ReferenceRepository : NHUpdateEntityRepository<ReferenceData>, IReferenceRepository
    {
        public IEnumerable<ReferenceBriefData> GetList(int folderId, int pageIndex, int pageSize)
        {
            ArgumentValidator.IsNotNull("folderId", folderId);
            IList<ReferenceBriefData> results = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                IQuery query = CurrentSession.GetNamedQuery("GetReferenceBriefList");
                query.SetParameter("folderId", folderId);
                query.SetInt32("pageIndex", pageIndex);
                query.SetInt32("pageSize", pageSize);
                results = query.List<ReferenceBriefData>();
            });

            return results;
        }

        public ReferenceInfoData GetReference(object id)
        {
            ArgumentValidator.IsNotNull("id", id);
            ReferenceInfoData result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<ReferenceInfoData>();
                query.AddExpressionEq<ReferenceInfoData, object>(o => o.Id, id);
                result = query.UniqueResult<ReferenceInfoData>();
                AttachAdditionalContent(result);
            });

            return result;
        }

        public ReferenceInfoData GetReference(string urlAlias)
        {
            return GetReference(urlAlias, null, null);
        }

        public ReferenceInfoData GetReference(string urlAlias, object locationId, object languageId)
        {
            ArgumentValidator.IsNotNull("urlAlias", urlAlias);
            ReferenceInfoData result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<ReferenceInfoData>();
                query.AddExpressionInsensitiveLike<ReferenceInfoData, string>(o => o.UrlAlias, urlAlias);
                result = query.UniqueResult<ReferenceInfoData>();
                AttachAdditionalContent(result, locationId, languageId);
            });

            return result;
        }

        public IEnumerable<SubjectInfoData> GetAttachedSubjects(object refId, object subitemId, int pageIndex, int pageSize, object locationId = null, object languageId = null)
        {
            ArgumentValidator.IsNotNull("refId", refId);
            ArgumentValidator.IsNotNull("subitemId", subitemId);

            ReferenceInfoData reference = null;
            // Retrieve reference by refId
            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<ReferenceInfoData>();
                query.AddExpressionEq<ReferenceInfoData, object>(o => o.Id, refId);
                reference = query.UniqueResult<ReferenceInfoData>();
            });

            // Get attached content
            IEnumerable<SubjectInfoData> result = null;
            if (reference != null)
            {
                SubitemValueInfoData value = reference.Values.SingleOrDefault(o => object.Equals(o.SubitemId, subitemId));
                if (value != null && value.ValueInt.HasValue)
                {
                    object templateId = value.ValueInt.Value;
                    int? categoryId = value.ValueText.TryToParse<int>();
                    result = GetSubjectsByTemplate(templateId, categoryId, pageIndex, pageSize, reference.SubsiteId, locationId, languageId);
                }
            }
            return result;
        }

        public IEnumerable<SubjectInfoData> GetSubjectsByTemplate(object templateId, object categoryId, int pageIndex, int pageSize, object subsiteId = null, object locationId = null, object languageId = null)
        {
            ArgumentValidator.IsNotNull("templateId", templateId);

            IEnumerable<SubjectInfoData> result = null;

            IQuery query = CurrentSession.GetNamedQuery("GetReferencesByTemplate");
            query.SetParameter("templateId", templateId);
            if (categoryId != null)
            {
                query.SetParameter("categoryId", categoryId);
            }
            else
            {
                query.SetString("categoryId", null);
            }
            query.SetInt32("pageIndex", pageIndex);
            query.SetInt32("pageSize", pageSize);
            // set locationId
            if (locationId != null)
            {
                query.SetParameter("locationId", locationId);
            }
            else
            {
                query.SetString("locationId", null);
            }
            // set languageId
            if (languageId != null)
            {
                query.SetParameter("languageId", languageId);
            }
            else
            {
                query.SetString("languageId", null);
            }
            // set SubSIteId
            if (subsiteId != null)
            {
                query.SetParameter("subsiteId", subsiteId);
            }
            else
            {
                query.SetString("subsiteId", null);
            }
            result = query.List<SubjectInfoData>();
            return result;
        }

        public IEnumerable<SubjectInfoData> GetSubjectsByKeyword(object keywordId, object templateId, int pageIndex, int pageSize, object languageId = null)
        {
            ArgumentValidator.IsNotNull("keywordId", keywordId);

            IEnumerable<SubjectInfoData> result = null;

            IQuery query = CurrentSession.GetNamedQuery("GetReferencesByKeyword");
            query.SetParameter("keywordId", keywordId);
            query.SetParameter("templateId", templateId);
            query.SetInt32("pageIndex", pageIndex);
            query.SetInt32("pageSize", pageSize);
            // set languageId
            if (languageId != null)
            {
                query.SetParameter("languageId", languageId);
            }
            else
            {
                query.SetString("languageId", null);
            }
            result = query.List<SubjectInfoData>();
            return result;
        }

        public IEnumerable<SubjectInfoData> GetSubjectsByCategory(object categoryId, object templateId, int pageIndex, int pageSize, object languageId = null)
        {
            ArgumentValidator.IsNotNull("categoryId", categoryId);

            IEnumerable<SubjectInfoData> result = null;

            IQuery query = CurrentSession.GetNamedQuery("GetReferencesByCategory");
            query.SetParameter("categoryId", categoryId);
            query.SetParameter("templateId", templateId);
            query.SetInt32("pageIndex", pageIndex);
            query.SetInt32("pageSize", pageSize);
            // set languageId
            if (languageId != null)
            {
                query.SetParameter("languageId", languageId);
            }
            else
            {
                query.SetString("languageId", null);
            }
            result = query.List<SubjectInfoData>();
            return result;
        }

        private void AttachAdditionalContent(ReferenceInfoData reference, object locationId = null, object languageId = null)
        {
            // Get related content for current reference
            if (reference.Template.EnableCategory)
            {
                object templateId = reference.Template.Id;
                int pageSize = reference.Template.RelatedContentNo == 0 ? 6 : reference.Template.RelatedContentNo;
                object categoryId = null;
                ReferenceCategoryInfoData firstCategory = null;
                if (reference.ReferenceCategorys.Any())
                {
                    firstCategory = reference.ReferenceCategorys.First();
                }
                if (firstCategory != null)
                {
                    categoryId = firstCategory.Category.Id;
                    reference.RelatedSubjects = GetSubjectsByCategory(categoryId, templateId, 1, pageSize);
                }
                else
                {
                    reference.RelatedSubjects = GetSubjectsByTemplate(templateId, null, 1, pageSize);
                }
            }
            foreach (ZoneInfoData zone in reference.Template.Zones)
            {
                if (zone.Block != null)
                {
                    foreach (SubitemInfoData item in zone.Block.Subitems)
                    {
                        if (item.DucType == DucTypes.ReferenceCollection)
                        {
                            // get collectionId
                            SubitemValueInfoData value = reference.Values.SingleOrDefault(o => object.Equals(o.SubitemId, item.Id));
                            if (value != null && value.ValueInt.HasValue)
                            {
                                IQuery query1 = CurrentSession.GetNamedQuery("GetReferencesByCollection");
                                query1.SetParameter("collectionId", value.ValueInt.Value);
                                // set locationId
                                if (locationId != null)
                                {
                                    query1.SetParameter("locationId", locationId);
                                }
                                else
                                {
                                    query1.SetString("locationId", null);
                                }
                                // set languageId
                                if (languageId != null)
                                {
                                    query1.SetParameter("languageId", languageId);
                                }
                                else
                                {
                                    query1.SetString("languageId", null);
                                }
                                value.AttachedSubjects = query1.List<SubjectInfoData>();
                            }
                        }
                        else if (item.DucType == DucTypes.CommentList)
                        {
                            // get comment list
                        }
                    }
                }
            }
        }
    }
}
