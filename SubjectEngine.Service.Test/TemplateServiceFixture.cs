using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class TemplateServiceFixture : FixtureBase
    {
        [TestMethod]
        public void GetTemplatesInfo_ReturnList()
        {
            ITemplateService service = UnitOfWork.GetService<ITemplateService>();
            IServiceQueryResultList<TemplateInfoData> result = service.GetTemplatesInfo();
            List<TemplateInfoData> list = result.DataList.ToList();

            var query = service.GetTemplateInfo(9);
            if (query != null)
            {
            }
        }
    }
}
