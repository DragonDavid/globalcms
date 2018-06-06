using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Business;
using SubjectEngine.Core;
using SubjectEngine.Data;
using SubjectEngine.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubjectEngine.Component
{
    internal class ApplicationSettingSystem : BusinessComponent
    {
        public ApplicationSettingSystem(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        internal IEnumerable<TDto> RetrieveAllApplicationSetting<TDto>(IDataConverter<ApplicationSettingData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IApplicationSettingService service = UnitOfWork.GetService<IApplicationSettingService>();

            var query = service.GetAll();

            if (query.HasResult)
            {
                return query.DataToDtoList(converter);
            }

            return null;
        }

        internal TDto RetrieveOrNewApplicationSetting<TDto>(object instanceId, IDataConverter<ApplicationSettingData, TDto> converter)
            where TDto : class
        {
            ArgumentValidator.IsNotNull("converter", converter);
            IApplicationSettingService service = UnitOfWork.GetService<IApplicationSettingService>();
            FacadeUpdateResult<ApplicationSettingData> result = new FacadeUpdateResult<ApplicationSettingData>();
            ApplicationSetting instance = RetrieveOrNew<ApplicationSettingData, ApplicationSetting, IApplicationSettingService>(result.ValidationResult, instanceId);
            if (result.IsSuccessful)
            {
                return converter.Convert(instance.RetrieveData<ApplicationSettingData>());
            }
            else
            {
                return null;
            }
        }

        internal IFacadeUpdateResult<ApplicationSettingData> SaveApplicationSetting(ApplicationSettingData dto)
        {
            ArgumentValidator.IsNotNull("dto", dto);

            FacadeUpdateResult<ApplicationSettingData> result = new FacadeUpdateResult<ApplicationSettingData>();
            IApplicationSettingService service = UnitOfWork.GetService<IApplicationSettingService>();
            ApplicationSetting instance = RetrieveOrNew<ApplicationSettingData, ApplicationSetting, IApplicationSettingService>(result.ValidationResult, dto.Id);

            if (result.IsSuccessful)
            {
                instance.SettingKey = dto.SettingKey;
                instance.SettingValue = dto.SettingValue;

                var saveQuery = service.Save(instance);

                result.AttachResult(instance.RetrieveData<ApplicationSettingData>());
                result.Merge(saveQuery);
            }

            return result;
        }

        internal IFacadeUpdateResult<ApplicationSettingData> DeleteApplicationSetting(object instanceId)
        {
            ArgumentValidator.IsNotNull("instanceId", instanceId);

            FacadeUpdateResult<ApplicationSettingData> result = new FacadeUpdateResult<ApplicationSettingData>();
            IApplicationSettingService service = UnitOfWork.GetService<IApplicationSettingService>();
            var query = service.Retrieve(instanceId);
            if (query.HasResult)
            {
                ApplicationSetting instance = query.ToBo<ApplicationSetting>();
                var saveQuery = instance.Delete();
                result.Merge(saveQuery);
            }
            else
            {
                AddError(result.ValidationResult, "ApplicationSettingCannotBeFound");
            }

            return result;
        }

        internal ApplicationOption GetApplicationOption()
        {
            ApplicationOption option = new ApplicationOption();
            IApplicationSettingService service = UnitOfWork.GetService<IApplicationSettingService>();
            var query = service.GetAll();

            if (query.HasResult)
            {
                ParseSettings(option, query.DataList);
            }

            return option;
        }

        private void ParseSettings(ApplicationOption option, IEnumerable<ApplicationSettingData> settings)
        {
            ApplicationSettingData setting;

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.Name.ToString()));
            if (setting != null)
            {
                option.Name = setting.SettingValue;
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.IsTestMode.ToString()));
            if (setting != null)
            {
                try { option.IsTestMode = Convert.ToBoolean(setting.SettingValue); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.EnableSSL.ToString()));
            if (setting != null)
            {
                try { option.EnableSSL = Convert.ToBoolean(setting.SettingValue); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.EnableAds.ToString()));
            if (setting != null)
            {
                try
                {
                    option.EnableAds = Convert.ToBoolean(setting.SettingValue);
                }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.EnableNotification.ToString()));
            if (setting != null)
            {
                try { option.EnableNotification = Convert.ToBoolean(setting.SettingValue); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.NoticeContentBriefLength.ToString()));
            if (setting != null)
            {
                try { option.NoticeContentBriefLength = Convert.ToInt32(setting.SettingValue.Trim()); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.DateFormatString.ToString()));
            if (setting != null)
            {
                try { option.DateFormatString = setting.SettingValue.Trim(); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.DateTimeFormatString.ToString()));
            if (setting != null)
            {
                try { option.DateTimeFormatString = setting.SettingValue.Trim(); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.ImageServeRoot.ToString()));
            if (setting != null)
            {
                try { option.ImageServeRoot = setting.SettingValue.Trim(); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.BaseDirectory.ToString()));
            if (setting != null)
            {
                try { option.BaseDirectory = setting.SettingValue.Trim(); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.IsMultiLanguageSupported.ToString()));
            if (setting != null)
            {
                try { option.IsMultiLanguageSupported = Convert.ToBoolean(setting.SettingValue.Trim()); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.DefaultLanguageId.ToString()));
            if (setting != null)
            {
                try { option.DefaultLanguageId = Convert.ToInt32(setting.SettingValue.Trim()); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.EnableReview.ToString()));
            if (setting != null)
            {
                try { option.EnableReview = Convert.ToBoolean(setting.SettingValue.Trim()); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.EnableTracking.ToString()));
            if (setting != null)
            {
                try { option.EnableTracking = Convert.ToBoolean(setting.SettingValue.Trim()); }
                catch { }
            }
            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.IsMultiLocationSupported.ToString()));
            if (setting != null)
            {
                try { option.IsMultiLocationSupported = Convert.ToBoolean(setting.SettingValue.Trim()); }
                catch { }
            }

            setting = settings.SingleOrDefault(o => o.SettingKey.Equals(ApplicationSettingKeys.DefaultLocationId.ToString()));
            if (setting != null)
            {
                try { option.DefaultLocationId = Convert.ToInt32(setting.SettingValue.Trim()); }
                catch { }
            }
        }

        internal IList<BindingListItem> GetBindingList()
        {
            List<BindingListItem> dataSource = new List<BindingListItem>();
            IApplicationSettingService service = UnitOfWork.GetService<IApplicationSettingService>();
            var query = service.GetAll();
            if (query.HasResult)
            {
                foreach (ApplicationSettingData data in query.DataList)
                {
                    dataSource.Add(new BindingListItem(data.Id, data.SettingKey));
                }
            }

            return dataSource;
        }
    }
}
