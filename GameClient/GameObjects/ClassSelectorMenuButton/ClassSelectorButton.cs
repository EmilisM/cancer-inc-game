using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.ClassSelectorMenuButton
{
    public class ClassSelectorButton : Button
    {
        public ClassSelectorButton(ClassType type)
        {
            Name = $"{GameObjectName.ClassSelectorMenuButton.ToString()}{type.ToString()}";
            Content = type.ToString();

            Background = Brushes.Black;
            Foreground = Brushes.White;
            BorderBrush = Brushes.Black;

            FontSize = 24;
        }
    }
}
