using Global.Data;
using Global.DataConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class CollectionFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            CollectionFacade facade = new CollectionFacade(UnitOfWork);
            List<CollectionDto> result = facade.RetrieveAllCollection(new CollectionConverter());
            if (result != null)
            {
            }

            CollectionDto instance = facade.RetrieveOrNewCollection(1, new CollectionConverter());
            if (instance != null)
            {
            }
        }
    }
}
