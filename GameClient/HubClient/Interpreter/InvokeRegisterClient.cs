using GameClient.Constants;
using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.HubClient.Interpreter
{
    public class InvokeRegisterClient : AbstractInvoke
    {
        public override void Interpret(InvokeContext context)
        {
            if (context.Action == HubConstants.RegisterClient)
            {
                MainWindow.GameInfoHub.InvokeAsync(HubConstants.RegisterClient, context.ClassType, GameConstants.Rows,
                    GameConstants.Columns);
            }
        }
    }
}