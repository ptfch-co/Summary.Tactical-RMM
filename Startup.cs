namespace Summary.TacticalRMM
{
    using Summary.TacticalRMM.Services;
    using Summary.TacticalRMM.Settings;
    using Core.DisplayManagement.Handlers;
    using Core.Modules;
    using Core.Navigation;
    using Core.Settings;
     using Core.Workflows.Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Summary.TacticalRMM.Workflows.Task.Command.Send;


    [Feature(TacticalRMM.Features.TacticalRMM)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDisplayDriver<ISite>, TacticalRMMSettingsDisplayDriver>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<INavigationProvider, Menu>();

            services.AddTransient<IConfigureOptions<TacticalRMMSettings>, TacticalRMMSettingsConfiguration>();
            
            services.AddActivity<SendCommandInTacticalRMMTask, SendCommandInTacticalRMMDisplay>();
        }
    }
}