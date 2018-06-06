using Framework.Data;
using Framework.Data.NHibernate;
using NHibernate;
using SubjectEngine.Core;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using System.Collections.Generic;

namespace SubjectEngine.Repository
{
    public class FolderRepository : NHUpdateEntityRepository<FolderData>, IFolderRepository
    {
        public IEnumerable<FolderInfoData> GetFolders(FolderType folderType)
        {
            IEnumerable<FolderInfoData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<FolderInfoData>();
                query.AddExpressionEq<FolderInfoData, FolderType>(o => o.FolderType, folderType);
                result = query.List<FolderInfoData>();
            });

            return result;
        }

        public IEnumerable<FolderInfoData> GetSubsiteRootFolders()
        {
            IEnumerable<FolderInfoData> result = null;

            RepositoryExceptionWrapper.Wrap(GetType(), () =>
            {
                ICriteria query = CurrentSession.CreateCriteria<FolderInfoData>();
                query.AddExpressionEq<FolderInfoData, bool>(o => o.IsSubsiteRoot, true);
                result = query.List<FolderInfoData>();
            });

            return result;
        }
    }
}
