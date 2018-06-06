using Framework.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class FolderFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestSaveFolder()
        {
            // Mock data
            FolderDto dto = new FolderDto();
            dto.Name = "test1";
            dto.ParentId = 2;
            dto.FolderType = FolderType.Content;
            dto.IsPublished = true;
            dto.IsSubsiteRoot = true;
            dto.Sort = 201;
            dto.Slug = "test1";

            FolderData data = FolderConverter.ConvertToData(dto);
            FolderFacade facade = new FolderFacade(UnitOfWork);
            IFacadeUpdateResult<FolderData> result = facade.SaveFolder(data);
            if (result.IsSuccessful)
            {

            }
        }

        [TestMethod]
        public void TestGetFolders()
        {
            FolderFacade f = new FolderFacade(UnitOfWork);
            List<FolderInfoDto> folderList = f.GetFolders(FolderType.Content, new FolderInfoConverter());
            if (folderList != null)
            {
            }
        }
    }
}
