namespace Summary.TacticalRMM.Workflows.Task.Command.Send
{
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Microsoft.Extensions.Localization;
    using Summary.TacticalRMM.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class SendCommandInTacticalRMMTask : TaskActivity
    {
        private readonly IStringLocalizer<SendCommandInTacticalRMMTask> T;
        private readonly ICommandService _commandService;

        public SendCommandInTacticalRMMTask(IStringLocalizer<SendCommandInTacticalRMMTask> t,
            ICommandService commandService)
        {
            T = t;
            _commandService = commandService;
        }
        
        public override string Name => nameof(SendCommandInTacticalRMMTask);
        
        public override LocalizedString DisplayText => T[TacticalRMM.Localize.SOfSendCommandInTacticalRMM];
       
        public override LocalizedString Category => T[TacticalRMM.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(
                T[TacticalRMM.Workflows.Done]
            );
        }

        public string Code
        {
            get => GetProperty(()=>string.Empty);
            set => SetProperty(value);
        }

        public string Shell
        {
            get => GetProperty(()=>string.Empty);
            set => SetProperty(value);
        }

        public string Agent
        {
            get => GetProperty(()=>string.Empty);
            set => SetProperty(value);
        }

        public string Client
        {
            get => GetProperty(()=>string.Empty);
            set => SetProperty(value);
        }

        public string Site
        {
            get => GetProperty(()=>string.Empty);
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var code = workflowContext.GetInputOrDefault(Code);
            var shell = workflowContext.GetInputOrDefault(Shell);
            var agent = workflowContext.GetInputOrDefault(Agent);
            var client = workflowContext.GetInputOrDefault(Client);
            var site = workflowContext.GetInputOrDefault(Site);

            await _commandService.SendCommandAsync(code,
                shell,
                agent,
                client,
                site
            );

            return Outcomes(TacticalRMM.Workflows.Done);
        }
    }
}