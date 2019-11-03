using System.Windows;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuReceiver : IMainMenuReceiver
    {
        public void Play()
        {
            MainWindow.MainMenu.Visibility = Visibility.Hidden;
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public void Hide()
        {
            MainWindow.MainMenu.Visibility = Visibility.Hidden;
        }

        public void Show()
        {
            MainWindow.MainMenu.Visibility = Visibility.Visible;
        }
    }
}