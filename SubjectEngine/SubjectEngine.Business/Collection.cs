using Framework.Business;
using Framework.Validation;
using SubjectEngine.Data;
using System;

namespace SubjectEngine.Business
{
    public class Collection : BusinessObject<CollectionData>
    {        
        protected override void OnInitialize()
        {
            base.OnInitialize();

            CollectionItems = new ChildBoCollection<CollectionData, CollectionItem, CollectionItemData>
                (Service, Data.CollectionItemsData, this);
        }

        [ChildCollection]
        public ChildBoCollection<CollectionData, CollectionItem, CollectionItemData> CollectionItems
        {
            get;
            private set;
        }

        [RequiredField("CollectionNameRequired", "The Name must be defined.")]
        [StringLength("CollectionNameLength", "The Name must have a length less than {1}", MaxLength = 50)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        public object CreatedById
        {
            get { return Data.CreatedById; }
            set { Data.CreatedById = value; }
        }

        public DateTime CreatedDate
        {
            get { return Data.CreatedDate; }
            set { Data.CreatedDate = value; }
        }

        public DateTime ModifiedDate
        {
            get { return Data.ModifiedDate; }
            set { Data.ModifiedDate = value; }
        }
    }
}
