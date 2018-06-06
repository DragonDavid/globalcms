using Framework.Data;
using Framework.Service;
using Framework.Unity;
using Framework.UoW;
using Microsoft.Practices.Unity;

namespace Test.Registry
{
    public class CoreRegistry : IUnityRegistry
    {
        public void Initialize(IUnityContainer container)
        {
            container.RegisterType<IDataStoreResolver, DataStoreResolver>();
            container.RegisterType<IDataStoreManager, DataStoreManager>();
            container.RegisterType<IBusinessObjectFactory, BusinessObjectFactory>();
        }
    }
}
