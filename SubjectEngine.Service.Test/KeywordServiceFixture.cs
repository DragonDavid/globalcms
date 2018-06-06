using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class KeywordServiceFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            IKeywordService service = UnitOfWork.GetService<IKeywordService>();
            IServiceQueryResultList<KeywordData> result = service.GetAll();
            List<KeywordData> list = result.DataList.ToList();
            if (list != null)
            {
            }
        }
    }
}
