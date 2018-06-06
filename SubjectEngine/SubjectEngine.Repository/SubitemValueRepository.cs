using Framework.Data.NHibernate;
using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;

namespace SubjectEngine.Repository
{
    public class SubitemValueRepository : NHUpdateEntityRepository<SubitemValueData>, ISubitemValueRepository
    {
    }
}
