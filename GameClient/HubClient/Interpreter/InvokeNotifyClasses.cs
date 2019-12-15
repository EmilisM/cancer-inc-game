using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.HubClient.Interpreter
{
    public class InvokeNotifyClasses : AbstractInvoke
    {
        public override void Interpret(InvokeContext context)
        {
            if (context.Action == HubConstants.NotifyClasses)
            {
                MainWindow.GameInfoHub.InvokeAsync(HubConstants.NotifyClasses);
            }
        }
    }
}