using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class SubjectFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            SubjectFacade facade = new SubjectFacade(UnitOfWork);
            IList<SubjectDto> result = facade.RetrieveAllSubject(new SubjectConverter());
            Assert.IsNotNull(result);
        }
    }
}
