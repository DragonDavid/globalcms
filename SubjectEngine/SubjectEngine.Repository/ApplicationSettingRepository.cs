using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using Framework.Data.NHibernate;

namespace SubjectEngine.Repository
{
    public class ApplicationSettingRepository : NHUpdateEntityRepository<ApplicationSettingData>, IApplicationSettingRepository
    {
    }
}
