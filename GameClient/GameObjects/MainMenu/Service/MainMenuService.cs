using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GameClient.GameObjects.MainMenu.Prototype;

namespace GameClient.GameObjects.MainMenu.Service
{
    public class MainMenuService : IMainMenuService
    {
        public Grid CreateMainMenu(List<MainMenuButtonPrototype> buttons, UIElement title)
        {
            var mainMenuGrid = new Grid();

            var columnDefinition = new ColumnDefinition { Width = new GridLength(400) };
            mainMenuGrid.ColumnDefinitions.Add(columnDefinition);

            var rowTitleDefinition = new RowDefinition { Height = new GridLength(100) };
            mainMenuGrid.RowDefinitions.Add(rowTitleDefinition);

            title.SetValue(Grid.RowProperty, 0);
            mainMenuGrid.Children.Add(title);

            for (int index = 1; index <= buttons.Count; index++)
            {
                var button = buttons[index - 1];
                var rowDefinition = new RowDefinition { Height = new GridLength(100) };
                mainMenuGrid.RowDefinitions.Add(rowDefinition);

                button.SetValue(Grid.RowProperty, index);
                mainMenuGrid.Children.Add(button);
            }

            mainMenuGrid.Margin = new Thickness(50, 50, 0, 0);
            mainMenuGrid.Visibility = Visibility.Hidden;
            mainMenuGrid.Name = Name.MainMenu.ToString();

            return mainMenuGrid;
        }
    }
}