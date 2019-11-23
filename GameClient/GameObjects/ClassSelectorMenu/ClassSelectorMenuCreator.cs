using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.ClassSelectorMenuButton;
using GameClient.GameObjects.Menu;

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
            var buttonList = new List<Button>();

            foreach (var classButton in MainWindow.Classes.Select(classObject => new ClassSelectorButton(classObject.Type)))
            {
                classButton.Click += (sender, args) => OnButtonClick();

                buttonList.Add(classButton);
            }

            return buttonList;
        }
    }
}