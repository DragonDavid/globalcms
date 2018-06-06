using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class DataTypeServiceFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            IDataTypeService service = UnitOfWork.GetService<IDataTypeService>();
            IServiceQueryResultList<DataTypeData> result = service.GetAll();
            List<DataTypeData> list = result.DataList.ToList();
            if (list != null)
            {
            }
        }
    }
}
