namespace Summary.TacticalRMM.Services
{
    using Core.Workflows;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using Summary.TacticalRMM.Settings;
    using System;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net.Http;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    public interface ICommandService
    {
        Task SendCommandAsync(string code,
           string shell,
           string agent,
           string client,
           string site
       );
    }

    public class CommandService : ICommandService
    {
        private readonly TacticalRMMSettings _options;
        private readonly HttpRequestClient _client;

        public CommandService(IOptions<TacticalRMMSettings> options,
            HttpRequestClient client)
        {
            _options = options.Value;
            _client = client;
        }

        public async Task SendCommandAsync(string code,
            string shell,
            string agent,
            string client,
            string site)
        {
            var agents = await _client.SendGetRequestAsync<IEnumerable<AgentInfo>>(
                $"{_options.ApiAddress}/agents",
                new KeyValuePair<string, string>("X-API-KEY", _options.Token)
            );

            var agentId = agents.FirstOrDefault(a =>
               a.Hostname == agent &&
               a.Client_Name == client &&
               a.Site_Name == site)?.Agent_Id;

            if (agentId == null) throw new NotImplementedException();

            var data = new
            {
                cmd = code,
                shell = shell,
                timeout=90,
                run_as_user = false
            };

            await _client.SendPostRequestAsync<string>(
                $"{_options.ApiAddress}/agents/{agentId}/cmd/",
                data,
                new[]
                {
                  new KeyValuePair<string, string>("X-API-KEY",_options.Token)
                }
            );
        }
    }
}
