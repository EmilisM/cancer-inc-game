using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GameClient.Constants;

namespace GameClient.GameObjects.Menu
{
    public abstract class MenuCreatorTemplate
    {
        protected abstract GameObjectName GetObjectName();

        protected abstract Label CreateMenuTitle();

        protected abstract List<Button> CreateMenuButtons();

        public Grid CreateMenu()
        {
            var menuGrid = new Grid
            {
                Margin = new Thickness(GameConstants.MainWindowWidth * 0.05, GameConstants.GameViewCanvasHeight * 0.05, 0, 0),
                Visibility = Visibility.Visible,
                Name = GetObjectName().ToString()
            };

            var columnDefinition = new ColumnDefinition { Width = new GridLength(GameConstants.MainWindowWidth * 0.4) };
            menuGrid.ColumnDefinitions.Add(columnDefinition);

            var rowTitleDefinition = new RowDefinition { Height = new GridLength(GameConstants.GameViewCanvasHeight * 0.16) };
            menuGrid.RowDefinitions.Add(rowTitleDefinition);

            var title = CreateMenuTitle();

            title.SetValue(Grid.RowProperty, 0);
            menuGrid.Children.Add(title);

            var buttons = CreateMenuButtons();

            for (var index = 1; index <= buttons.Count; index++)
            {
                var button = buttons[index - 1];
                var rowDefinition = new RowDefinition { Height = new GridLength(GameConstants.GameViewCanvasHeight * 0.16) };
                menuGrid.RowDefinitions.Add(rowDefinition);

                button.SetValue(Grid.RowProperty, index);
                menuGrid.Children.Add(button);
            }

            return menuGrid;
        }
    }
}