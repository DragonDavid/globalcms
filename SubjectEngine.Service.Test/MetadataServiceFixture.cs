using System.Collections.Generic;
using System.Linq;
using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class MetadataServiceFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            IMetadataService service = UnitOfWork.GetService<IMetadataService>();
            IServiceQueryResultList<MetadataData> result = service.GetAll();
            List<MetadataData> list = result.DataList.ToList();
            if (list != null)
            {
            }
        }
    }
}
