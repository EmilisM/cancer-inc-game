using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.HubClient.Interpreter
{
    public class InvokeBuildTower : AbstractInvoke
    {
        public override void Interpret(InvokeContext context)
        {
            if (context.Action == HubConstants.BuildTower)
            {
                MainWindow.GameInfoHub.InvokeAsync(HubConstants.BuildTower, context.TowerName, context.TowerCost,
                    MainWindow.SelectedRow,
                    MainWindow.SelectedColumn);
            }
        }
    }
}