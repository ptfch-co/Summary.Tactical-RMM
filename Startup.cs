namespace Summary.TacticalRMM
{
    using Core.DisplayManagement.Handlers;
    using Core.Modules;
    using Core.Navigation;
    using Core.Settings;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Summary.TacticalRMM.Settings;

    [Feature(TacticalRMM.Features.TacticalRMM)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<INavigationProvider, Menu>();
            services.AddScoped<IDisplayDriver<ISite>, IdealCrmSettingsDisplayDriver>();

            services.AddTransient<IConfigureOptions<TacticalRMMSettings>, IdealCrmSettingsConfiguration>();
        }
    }
}