namespace Summary.TacticalRMM.Workflows.Task.Command.Send
{
    using Core.Workflows.Display;

    public class SendCommandInTacticalRMMDisplay : ActivityDisplayDriver<SendCommandInTacticalRMMTask,
        SendCommandInTacticalRMMViewModel>
    {
        protected override void EditActivity(SendCommandInTacticalRMMTask activity, SendCommandInTacticalRMMViewModel model)
        {
            model.Code = activity.Code;
            model.Shell = activity.Shell;
            model.Agent = activity.Agent;
            model.Client = activity.Client;
            model.Site = activity.Site;
        }

        protected override void UpdateActivity(SendCommandInTacticalRMMViewModel model,
            SendCommandInTacticalRMMTask activity)
        {
            activity.Code = model.Code;
            activity.Shell = model.Shell;
            activity.Agent = model.Agent;
            activity.Client = model.Client;
            activity.Site = model.Site;
        }
    }
}