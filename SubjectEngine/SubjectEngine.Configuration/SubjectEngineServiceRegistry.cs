using Framework.Unity;
using Microsoft.Practices.Unity;
using SubjectEngine.Service;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Configuration
{
    public class SubjectEngineServiceRegistry : IUnityRegistry
    {
        public void Initialize(IUnityContainer container)
        {
            container.RegisterType<IMainMenuService, MainMenuService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ILanguageService, LanguageService>();
            container.RegisterType<IApplicationSettingService, ApplicationSettingService>();
            container.RegisterType<IAliasService, AliasService>();
            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IBlockService, BlockService>();
            container.RegisterType<IReferenceService, ReferenceService>();
            container.RegisterType<ISubitemValueService, SubitemValueService>();
            container.RegisterType<IGridRowService, GridRowService>();
            container.RegisterType<IDEntityService, DEntityService>();
            container.RegisterType<IDataTypeService, DataTypeService>();
            container.RegisterType<IMetadataService, MetadataService>();
            container.RegisterType<ISubsiteService, SubsiteService>();
            container.RegisterType<IFolderService, FolderService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<ILocationService, LocationService>();
            container.RegisterType<ICollectionService, CollectionService>();
            container.RegisterType<IReviewService, ReviewService>();
            container.RegisterType<IKeywordService, KeywordService>();
        }
    }
}
