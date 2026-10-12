namespace Summary.TacticalRMM.Services
{

    using Summary.TacticalRMM.Settings;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net.Http;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;


    public interface ICommandService
    {
        Task SendCommandAsync(string code,
           string shell,
           string agent
       );
    }
    public class CommandService : ICommandService
    {
        private readonly TacticalRMMSettings _options;

        public CommandService(IOptions<TacticalRMMSettings> options)
        {
            _options = options.Value;
        }


        public Task SendCommandAsync(string code,
            string shell,
            string agent
        )
        {
            // Implement the logic to send the command here.
            return Task.CompletedTask;
        }
    }
}
