using System.Collections.Generic;
using System.Linq;
using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class SubjectServiceFixture : FixtureBase
    {
        [TestMethod]
        public void GetSubjects_ReturnList()
        {
            ISubjectService service = UnitOfWork.GetService<ISubjectService>();
            IServiceQueryResultList<SubjectData> result = service.GetAll();
            List<SubjectData> list = result.DataList.ToList();

            if (list != null)
            {
            }
        }
    }
}
