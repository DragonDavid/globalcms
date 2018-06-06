using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class DataTypeFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            DataTypeFacade facade = new DataTypeFacade(UnitOfWork);
            List<DataTypeDto> result = facade.RetrieveAll(new DataTypeConverter());
            Assert.IsNotNull(result);
        }
    }
}
