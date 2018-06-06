using Framework.Service;
using Framework.UoW;
using SubjectEngine.Core;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;

namespace SubjectEngine.Service
{
    public class FolderService : UpdateEntityService<IFolderRepository, FolderData>, IFolderService
    {
        public IServiceQueryResultList<FolderInfoData> GetFolders(FolderType folderType)
        {
            IEnumerable<FolderInfoData> result = Repository.GetFolders(folderType);
            return ServiceResultFactory.BuildServiceQueryResult<FolderInfoData>(result);
        }

        public IServiceQueryResultList<FolderInfoData> GetSubsiteRootFolders()
        {
            IEnumerable<FolderInfoData> result = Repository.GetSubsiteRootFolders();
            return ServiceResultFactory.BuildServiceQueryResult<FolderInfoData>(result);
        }
    }
}
