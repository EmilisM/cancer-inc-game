using System.Windows;
using GameClient.HubClient;
using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient
{
    public partial class App
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            GameClient.MainWindow.GameInfoHub?.InvokeAsync(HubConstants.RemoveClient);
        }
    }
}