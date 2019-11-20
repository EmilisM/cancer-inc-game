using System.Windows.Controls;
using System.Windows.Media;

namespace GameClient.GameObjects.MainMenuButton
{
    public abstract class MainMenuButtonPrototype : Button
    {
        protected MainMenuButtonPrototype(MainMenuButtonType type)
        {
            Name = $"{GameObjectName.MainMenuButton.ToString()}{type.ToString()}";
            Content = type.ToString();
            Background = Brushes.Black;
            Foreground = Brushes.White;
            BorderBrush = Brushes.Black;

            FontSize = 24;

            MainWindow.CompositeLogger.LogMessage($"MainMenuButtonPrototype called with name: {type.ToString()}");
        }

        public abstract MainMenuButtonPrototype ShallowClone();

        public abstract MainMenuButtonPrototype DeepClone();
    }
}