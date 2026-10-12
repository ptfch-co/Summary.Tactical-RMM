namespace Summary.TacticalRMM
{
    using Summary.TacticalRMM.Services;
    using Summary.TacticalRMM.Settings;
    using Core.DisplayManagement.Handlers;
    using Core.Modules;
    using Core.Navigation;
    using Core.Settings;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;



    [Feature(TacticalRMM.Features.TacticalRMM)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDisplayDriver<ISite>, TacticalRMMSettingsDisplayDriver>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddTransient<IConfigureOptions<TacticalRMMSettings>, IdealCrmSettingsConfiguration>();
            services.AddActivity<SendCommandInTacticalRMMTask, SendCommandInTacticalRMMDisplay>();

        }
    }
}