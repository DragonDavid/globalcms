using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace SubjectEngine.Component
{
    public class LanguageFacade : BusinessComponent
    {
        public LanguageFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            LanguageSystem = new LanguageSystem(unitOfWork);
        }

        private LanguageSystem LanguageSystem { get; set; }

        public IEnumerable<TDto> RetrieveAllLanguage<TDto>(IDataConverter<LanguageData, TDto> converter)
            where TDto : class
        {
            UnitOfWork.BeginTransaction();
            IEnumerable<TDto> instances = LanguageSystem.RetrieveAllLanguage(converter);
            UnitOfWork.CommitTransaction();
            return instances;
        }

        public IList<BindingListItem> GetBindingList()
        {
            return LanguageSystem.GetBindingList();
        }
    }
}
