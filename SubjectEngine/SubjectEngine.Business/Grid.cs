using Framework.Business;
using Framework.Validation;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace SubjectEngine.Business
{
    public class Grid : BusinessObject<GridData>
    {        
        protected override void OnInitialize()
        {
            base.OnInitialize();

            Columns = new ChildBoCollection<GridData, GridColumn, GridColumnData>
                (Service, Data.Columns, this);
        }

        [ChildCollection]
        public ChildBoCollection<GridData, GridColumn, GridColumnData> Columns
        {
            get;
            private set;
        }

        [StringLength("GridNameLength", "The Name must have a length less than {1}", MaxLength = 50)]
        public string Name
        {
            get { return Data.Name; }
            set { Data.Name = value; }
        }

        public ViewMode ViewMode
        {
            get { return Data.ViewMode; }
            set { Data.ViewMode = value; }
        }
    }
}
