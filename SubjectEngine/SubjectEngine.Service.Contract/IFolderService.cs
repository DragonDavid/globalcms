using Framework.Service;
using Framework.UoW;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace SubjectEngine.Service.Contract
{
    public interface IFolderService : IUpdateEntityService<FolderData>
    {
        IServiceQueryResultList<FolderInfoData> GetFolders(FolderType folderType);
        IServiceQueryResultList<FolderInfoData> GetSubsiteRootFolders();
    }
}
