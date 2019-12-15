using System.Windows;
using GameClient.HubClient;
using GameClient.HubClient.Interpreter;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuReceiver : IMainMenuReceiver
    {
        public void Play()
        {
            MainWindow.MainMenu.Visibility = Visibility.Hidden;
            MainWindow.InvokeActions(new InvokeContext
            {
                Action = HubConstants.NotifyClasses
            });

            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Play");
        }

        public void Exit()
        {
            Application.Current.Shutdown();
            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Exit");
        }

        public void Reset()
        {
            MainWindow.InvokeActions(new InvokeContext
            {
                Action = HubConstants.ResetGame
            });

            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Reset");
        }
    }
}