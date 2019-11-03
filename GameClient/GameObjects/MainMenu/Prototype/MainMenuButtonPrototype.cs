using System.Windows.Controls;
using System.Windows.Media;

namespace GameClient.GameObjects.MainMenu.Prototype
{
    public abstract class MainMenuButtonPrototype : Button
    {
        protected MainMenuButtonPrototype(string name)
        {
            Name = $"{GameObjectName.MainMenuButton.ToString()}{name}";
            Content = name;
            Background = Brushes.Black;
            Foreground = Brushes.White;
            BorderBrush = Brushes.Black;

            FontSize = 24;

            MainWindow.CompositeLogger.LogMessage($"MainMenuButtonPrototype called with name: {name}");
        }

        public abstract MainMenuButtonPrototype ShallowClone();

        public abstract MainMenuButtonPrototype DeepClone();
    }
}