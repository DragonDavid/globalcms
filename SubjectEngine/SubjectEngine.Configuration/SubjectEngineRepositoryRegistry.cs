using Framework.Unity;
using Microsoft.Practices.Unity;
using SubjectEngine.Repository;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Configuration
{
    public class SubjectEngineRepositoryRegistry : IUnityRegistry
    {
        public void Initialize(IUnityContainer container)
        {
            container.RegisterType<IMainMenuRepository, MainMenuRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ILanguageRepository, LanguageRepository>();
            container.RegisterType<IApplicationSettingRepository, ApplicationSettingRepository>();
            container.RegisterType<IAliasRepository, AliasRepository>();
            container.RegisterType<IDocumentRepository, DocumentRepository>();
            container.RegisterType<ITemplateRepository, TemplateRepository>();
            container.RegisterType<IBlockRepository, BlockRepository>();
            container.RegisterType<IReferenceRepository, ReferenceRepository>();
            container.RegisterType<ISubitemValueRepository, SubitemValueRepository>();
            container.RegisterType<IGridRowRepository, GridRowRepository>();
            container.RegisterType<IDEntityRepository, DEntityRepository>();
            container.RegisterType<IDataTypeRepository, DataTypeRepository>();
            container.RegisterType<IMetadataRepository, MetadataRepository>();
            container.RegisterType<ISubsiteRepository, SubsiteRepository>();
            container.RegisterType<IFolderRepository, FolderRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<ICollectionRepository, CollectionRepository>();
            container.RegisterType<IReviewRepository, ReviewRepository>();
            container.RegisterType<IKeywordRepository, KeywordRepository>();
        }
    }
}
