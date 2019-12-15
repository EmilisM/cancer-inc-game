using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.HubClient.Interpreter
{
    public class InvokeResetGame : AbstractInvoke
    {
        public override void Interpret(InvokeContext context)
        {
            if (context.Action == HubConstants.ResetGame)
            {
                MainWindow.GameInfoHub.InvokeAsync(HubConstants.ResetGame);
            }
        }
    }
}