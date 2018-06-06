using Framework.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class SubsiteFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            SubsiteFacade facade = new SubsiteFacade(UnitOfWork);
            SubsiteInfoDto item = facade.GetSubsiteInfo<SubsiteInfoDto>(8, new SubsiteInfoConverter());
            if (item != null)
            {
            }

            List<SubsiteBriefDto> result = facade.GetSubsites<SubsiteBriefDto>(new SubsiteBriefConverter());
            if (result != null)
            {
            }
        }
    }
}
