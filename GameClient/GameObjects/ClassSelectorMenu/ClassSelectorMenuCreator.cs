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
                Name = GameObjectName.ClassSelectorMenuTitle.ToString(),
                Foreground = Brushes.White,
                Content = "Select class",
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return title;
        }

        private static void OnButtonClick()
        {
            MainWindow.ClassSelectorMenu.Visibility = Visibility.Hidden;
            MainWindow.GameUi.Visibility = Visibility.Visible;
        }

        protected override List<Button> CreateMenuButtons()
        {
            var greenClassButton = new ClassSelectorButton(ClassType.Green);
            greenClassButton.Click += (sender, args) => OnButtonClick();

            var yellowClassButton = new ClassSelectorButton(ClassType.Yellow);
            yellowClassButton.Click += (sender, args) => OnButtonClick();

            var whiteClassButton = new ClassSelectorButton(ClassType.White);
            whiteClassButton.Click += (sender, args) => OnButtonClick();

            var redClassButton = new ClassSelectorButton(ClassType.Red);
            redClassButton.Click += (sender, args) => OnButtonClick();

            return new List<Button>
            {
                greenClassButton,
                yellowClassButton,
                whiteClassButton,
                redClassButton
            };
        }
    }
}