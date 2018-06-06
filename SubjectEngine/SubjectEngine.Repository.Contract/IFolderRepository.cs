using Framework.Data;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Repository.Contract
{
    public interface IFolderRepository : IUpdateEntityRepository<FolderData>
    {
        IEnumerable<FolderInfoData> GetFolders(FolderType folderType);
        IEnumerable<FolderInfoData> GetSubsiteRootFolders();
    }
}
