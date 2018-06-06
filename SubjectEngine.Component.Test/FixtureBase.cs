using Framework.Unity;
using Framework.UoW;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Configuration;
using System.Collections.Generic;
using Test.Registry;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class FixtureBase
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        [TestInitialize]
        public void Setup()
        {
            InitUnity();
            InitFramework();

            UnitOfWork = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey);
        }

        private void InitUnity()
        {
            IList<IUnityRegistry> registries = new List<IUnityRegistry>();
            registries.Add(new CoreRegistry());
            registries.Add(new SubjectEngineRepositoryRegistry());
            registries.Add(new SubjectEngineServiceRegistry());
            UnityLibrary library = new UnityLibrary(registries);
            library.InitializeServiceLocator();
        }

        private void InitFramework()
        {
            IDataStoreManager storeManager = ServiceLocator.Current.GetInstance<IDataStoreManager>();
            EntityResolver entityResolver = ServiceLocator.Current.GetInstance<EntityResolver>();
            IBusinessObjectFactory factory = ServiceLocator.Current.GetInstance<IBusinessObjectFactory>();
            UnitOfWorkFactory.Instance.Initialize(storeManager, entityResolver, entityResolver, factory);
        }

        //[TestMethod]
        //public void TestGetReferenceById()
        //{
        //    ReferenceInfoFacade facade = new ReferenceInfoFacade(UnitOfWork);
        //    ReferenceInfoDto item = facade.GetReferenceInfo(1);
        //    if (item.Template.Zones != null)
        //    {
        //    }
        //    ReferenceInfoDto item12 = facade.GetReferenceInfo(12);
        //    if (item12.Template.Zones != null)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestGetReferenceByAlias()
        //{
        //    ReferenceInfoFacade facade = new ReferenceInfoFacade(UnitOfWork);
        //    ReferenceInfoDto item = facade.GetReferenceInfo("home");
        //    if (item != null)
        //    {
        //    }

        //    item = facade.GetReferenceInfo("blog/test-blog");
        //    if (item != null)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestGetFolders()
        //{
        //    ReferenceInfoFacade facade = new ReferenceInfoFacade(UnitOfWork);
        //    List<FolderInfoDto> list = facade.GetFolders(FolderType.Content);
        //    List<FolderInfoDto> list2 = facade.GetFolders(FolderType.Document);

        //    if (list.Count > 0)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestGetTemplatesInfo()
        //{
        //    TemplateFacade facade = new TemplateFacade(UnitOfWork);
        //    List<TemplateInfoDto> list = facade.GetTemplatesInfo();
        //    if (list.Count > 0)
        //    {
        //    }

        //    TemplateInfoDto item7 = facade.GetTemplateInfo(7);
        //    if (item7 != null)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestGetBlocksInfo()
        //{
        //    BlockFacade facade = new BlockFacade(UnitOfWork);
        //    List<BlockInfoDto> list = facade.GetBlocksInfo();
        //    if (list.Count > 0)
        //    {
        //    }

        //    BlockInfoDto item7 = facade.GetBlockInfo(7);
        //    if (item7 != null)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestDocumentSave()
        //{
        //    DocumentFacade facade = new DocumentFacade(UnitOfWork);

        //    DocumentDto item = new DocumentDto
        //    {
        //        Title = "test1",
        //        FileName="sarah.jpg",
        //        ContentUri="/uploads/sarah.jpg"
        //    };

        //    IFacadeUpdateResult<DocumentData> result = facade.SaveDocument(item);
        //    if (result.IsSuccessful)
        //    {
        //        DocumentDto savedInstance = result.ToDto<DocumentDto>(new DocumentConverter());
        //    }
        //}
        //[TestMethod]
        //public void TestSaveGridRow()
        //{
        //    GridRowDto row = new GridRowDto();
        //    row.Id = 4;
        //    row.ReferenceId = 1;
        //    row.GridId = 2;
        //    List<DucValueDto> cells = new List<DucValueDto>();
        //    row.Cells = cells;
        //    cells.Add(new DucValueDto { DucId = 4, ValueText = "imageText", ValueUrl = "http://placehold.it/400x200" });
        //    cells.Add(new DucValueDto { DucId = 5, ValueText = "LinkText", ValueUrl = "/linkHref/v2" });

        //    ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
        //    IFacadeUpdateResult<GridRowData> result = facade.SaveGridRow(row);
        //    if (result.IsSuccessful)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestSetPublish()
        //{
        //    ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
        //    bool result = facade.SetPublish(2, true);
        //    if (result)
        //    {
        //    }
        //    result = facade.SetPublish(2, false);
        //    if (result)
        //    {
        //    }
        //}

        //[TestMethod]
        //public void TestAddReferenceCategory()
        //{
        //    List<CategoryDto> items = new List<CategoryDto>();
        //    CategoryDto k1 = new CategoryDto { Id = 5 };
        //    items.Add(k1);
        //    ReferenceInfoDto reference = new ReferenceInfoDto();
        //    reference.ReferenceId = 16;
        //    reference.ReferenceCategorys = items;

        //    ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
        //    IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceCategorys(reference);
        //    if (result.IsSuccessful)
        //    {
        //    }
        //}

    }
}
