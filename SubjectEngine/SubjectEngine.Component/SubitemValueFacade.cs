using Framework.Component;
using Framework.Core;
using Framework.UoW;
using General.Utility.Excel;
using SubjectEngine.Business;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class SubitemValueFacade : BusinessComponent
    {
        public SubitemValueFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            SubitemValueSystem = new SubitemValueSystem(unitOfWork);
        }

        private SubitemValueSystem SubitemValueSystem { get; set; }

    }
}
