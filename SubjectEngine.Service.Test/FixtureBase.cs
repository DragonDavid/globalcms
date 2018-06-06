using Framework.Unity;
using Framework.UoW;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Configuration;
using System.Collections.Generic;
using Test.Registry;

namespace SubjectEngine.Service.Test
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
    }
}
