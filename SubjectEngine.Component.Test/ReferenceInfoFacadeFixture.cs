using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class ReferenceInfoFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            ReferenceInfoFacade facade = new ReferenceInfoFacade(UnitOfWork);

            var result = facade.GetSubjectsByKeyword(22, 9, 1, 10, 1, new SubjectInfoConverter());

            //result = facade.GetSubjectsByTemplate(9, null, 1, 10, null, null, 1, new SubjectInfoConverter());

            //List<FolderInfoDto> list = facade.GetFolders(Core.FolderType.Content, new FolderInfoConverter());

            List<ReferenceBriefDto> result11 = facade.GetList<ReferenceBriefDto>(30, 1, 10, new ReferenceBriefConverter(2));
            if (result11 != null)
            {
            }

            List<ReferenceBriefDto> result113 = facade.GetList<ReferenceBriefDto>(12, 1, 10, new ReferenceBriefConverter());
            if (result113 != null)
            {
            }

            //var result = facade.GetAttachedSubjects<SubjectInfoDto>(3968, 17, 1, 10, 1, 1, new SubjectInfoConverter());
            //if (result != null)
            //{
            //}

            ReferenceInfoDto item = facade.GetReferenceInfo<ReferenceInfoDto>(3965, new ReferenceInfoConverter());
            if (item != null)
            {
            }
        }
    }
}
