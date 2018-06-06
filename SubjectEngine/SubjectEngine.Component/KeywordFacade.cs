using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Component
{
    public class KeywordFacade : BusinessComponent
    {
        public KeywordFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            KeywordSystem = new KeywordSystem(unitOfWork);
        }

        private KeywordSystem KeywordSystem { get; set; }

        public List<TDto> RetrieveAll<TDto>(IDataConverter<KeywordData, TDto> converter)
            where TDto : class
        {
            List<TDto> instances = KeywordSystem.RetrieveAll(converter);
            if (instances == null)
            {
                instances = new List<TDto>();
            }
            return instances;
        }

        public IEnumerable<BindingListItem> GetBindingList()
        {
            return KeywordSystem.GetBindingList();
        }
    }
}
