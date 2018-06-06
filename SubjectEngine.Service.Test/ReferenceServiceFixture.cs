﻿using Framework.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectEngine.Core;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Service.Test
{
    [TestClass]
    public class ReferenceServiceFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            IReferenceService service = UnitOfWork.GetService<IReferenceService>();

            var result = service.GetReference(10);
            if (result != null)
            {
            }
        }
    }
}
