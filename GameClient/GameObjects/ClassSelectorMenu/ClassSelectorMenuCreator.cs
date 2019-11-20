using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.ClassSelectorMenuButton;
using GameClient.GameObjects.Menu;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.ClassSelectorMenu
{
    public class ClassSelectorMenuCreator : MenuCreatorTemplate
    {
        protected override GameObjectName GetObjectName()
        {
            return GameObjectName.ClassSelectorMenu;
        }

        protected override Label CreateMenuTitle()
        {
            var title = new Label
            {
                Foreground = Brushes.White,
                Content = "Select class",
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return title;
        }

        protected override List<Button> CreateMenuButtons()
        {
            return new List<Button>
            {
                new ClassSelectorButton(ClassType.Green),
                new ClassSelectorButton(ClassType.Yellow),
                new ClassSelectorButton(ClassType.White),
                new ClassSelectorButton(ClassType.Red)
            };
        }
    }
}