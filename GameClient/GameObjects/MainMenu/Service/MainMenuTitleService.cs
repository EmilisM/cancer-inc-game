using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameClient.GameObjects.MainMenu.Service
{
    public class MainMenuTitleService : IMainMenuTitleService
    {
        public UIElement GetMainMenuTitle()
        {
            var title = new Label
            {
                Foreground = Brushes.White,
                Content = "Cancer tower defense",
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return title;
        }
    }
}