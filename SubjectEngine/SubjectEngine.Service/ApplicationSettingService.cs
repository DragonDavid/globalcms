using SubjectEngine.Data;
using SubjectEngine.Repository.Contract;
using SubjectEngine.Service.Contract;
using Framework.Service;

namespace SubjectEngine.Service
{
    public class ApplicationSettingService : UpdateEntityService<IApplicationSettingRepository, ApplicationSettingData>, IApplicationSettingService
    {
    }
}
