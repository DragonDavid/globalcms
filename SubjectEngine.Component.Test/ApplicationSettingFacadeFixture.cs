using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Core;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class ApplicationSettingFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            ApplicationSettingFacade facade = new ApplicationSettingFacade(UnitOfWork);
            ApplicationOption list = facade.GetApplicationOption();
            if (list != null)
            {
            }
        }
    }
}
