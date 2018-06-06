using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class SubsiteServiceFixture : FixtureBase
    {
        [TestMethod]
        public void GetSubsitesInfo_ReturnList()
        {
            ISubsiteService service = UnitOfWork.GetService<ISubsiteService>();
            IServiceQueryResultList<SubsiteBriefData> result = service.GetSubsites();
            List<SubsiteBriefData> list = result.DataList.ToList();

            if (list != null)
            {
            }
        }
    }
}
