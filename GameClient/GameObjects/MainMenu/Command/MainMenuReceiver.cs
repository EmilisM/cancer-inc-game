using System.Windows;
using GameClient.HubClient;
using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuReceiver : IMainMenuReceiver
    {
        public void Play()
        {
            MainWindow.MainMenu.Visibility = Visibility.Hidden;
            MainWindow.GameInfoHub.InvokeAsync(HubConstants.NotifyClasses);

            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Play");
        }

        public void Exit()
        {
            Application.Current.Shutdown();
            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Exit");
        }
    }
}