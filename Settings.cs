namespace Summary.TacticalRMM.Settings
{
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Core.DisplayManagement.Entities;
    using Core.DisplayManagement.Handlers;
    using Core.DisplayManagement.Views;
    using Core.Entities;
    using Core.Environment.Shell;
    using Core.Settings;
    using Core.Workflows;


    public class TacticalRMMSettings
    {
        private string api_address;

        [Required]
        public string ApiAddress
        {
            get => api_address?.TrimEnd('/');
            set => api_address = value;
        }

        [Required]
        public string Token { get; set; }

    }

    public class TacticalRMMSettingsDisplayDriver : SectionDisplayDriver<ISite,
        TacticalRMMSettings>
    {
        private readonly IShellHost _host;
        private readonly ShellSettings _shell;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IAuthorizationService _authorize;

        public TacticalRMMSettingsDisplayDriver(IShellHost host,
            ShellSettings settings,
            IHttpContextAccessor httpContext,
            IAuthorizationService authorize)
        {
            _host = host;
            _shell = settings;
            _httpAccessor = httpContext;
            _authorize = authorize;
        }

        public override async Task<IDisplayResult> EditAsync(TacticalRMMSettings settings,
            BuildEditorContext context)
        {
            var user = _httpAccessor.HttpContext?.User;
            if (user is null || !await _authorize.AuthorizeAsync(user, Permissions.ManageWorkflows))
            {
                return null;
            }

            var init = Initialize<TacticalRMMSettings>("TacticalRMMSettings_Edit", model =>
            {
                model.ApiAddress = settings.ApiAddress;
                model.Token = settings.Token;
            });

            return init.Location("Content:5").OnGroup("TacticalRMM");
        }

        public override async Task<IDisplayResult> UpdateAsync(TacticalRMMSettings settings,
            BuildEditorContext context)
        {
            var user = _httpAccessor.HttpContext?.User;
            if (user is null || !await _authorize.AuthorizeAsync(user, Permissions.ManageWorkflows))
            {
                return null;
            }
            if (context.GroupId == "TacticalRMM")
            {
                await context.Updater.TryUpdateModelAsync(settings, Prefix);
                await _host.ReloadShellContextAsync(_shell);
            }
            return await EditAsync(settings, context);
        }
    }

    public class IdealCrmSettingsConfiguration : IConfigureOptions<TacticalRMMSettings>
    {
        private readonly ISiteService _site;
        private readonly ILogger<IdealCrmSettingsConfiguration> _logger;

        public IdealCrmSettingsConfiguration(ISiteService site,
            ILogger<IdealCrmSettingsConfiguration> logger)
        {
            _site = site;
            _logger = logger;
        }

        public void Configure(TacticalRMMSettings options)
        {
            var settings = _site.GetSiteSettingsAsync().GetAwaiter().GetResult().As<TacticalRMMSettings>();
            options.ApiAddress = settings.ApiAddress;
            options.Token = settings.Token;
        }
    }
}