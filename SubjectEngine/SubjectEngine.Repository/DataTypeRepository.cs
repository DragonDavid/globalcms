using Framework.Data.NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class DataTypeRepository : NHUpdateEntityRepository<DataTypeData>, IDataTypeRepository
    {
    }
}
