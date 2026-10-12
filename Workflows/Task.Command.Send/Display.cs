namespace Summary.TacticalRMM.Workflows.Task.Command.Send
{
    using System;
    using Core.Workflows.Display;
    
    public class SendCommandInTacticalRMMDisplay : ActivityDisplayDriver<SendCommandInTacticalRMMTask,
    SendCommandInTacticalRMMViewModel>
    {
        protected  override void EditActivity(SendCommandInTacticalRMMTask activity, SendCommandInTacticalRMMViewModel model)
        {
            model.Code=activity.Code;
            model.Shell=activity.Shell;
            model.Agent=activity.Agent;
        }

        protected  override void UpdateActivity(SendCommandInTacticalRMMViewModel model,
         SendCommandInTacticalRMMTask activity)
        {
            activity.Code=model.Code;
            activity.Shell=model.Shell;
            activity.Agent=model.Agent;
        }

    }
}