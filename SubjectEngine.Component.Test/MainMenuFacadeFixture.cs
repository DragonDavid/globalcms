using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class MainMenuFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            MainMenuFacade facade = new MainMenuFacade(UnitOfWork);
            List<MainMenuDto> result = facade.GetPublishedMenus<MainMenuDto>(new MainMenuConverter());
            if (result != null)
            {
            }
            List<MainMenuDto> result2 = facade.RetrieveAllMainMenu<MainMenuDto>(new MainMenuConverter());
            if (result2 != null)
            {
            }
        }

        [TestMethod]
        public void TestLocations()
        {
            LocationFacade facade = new LocationFacade(UnitOfWork);
            List<LocationDto> result = facade.GetPublishedLocations<LocationDto>(new LocationConverter());
            if (result != null)
            {
            }
            List<LocationDto> result2 = facade.RetrieveAllLocation<LocationDto>(new LocationConverter());
            if (result2 != null)
            {
            }
        }
    }
}
