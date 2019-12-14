using System;
using System.Windows;
using System.Windows.Controls;
using GameClient.Constants;

namespace GameClient.GameObjects.GameInterface
{
    public class TowerSelector : Grid
    {
        public TowerSelector()
        {
            const int rowHeight = 48;
            const int columnWidth = 48;

            var columnCount = Convert.ToInt32(Math.Floor(GameConstants.MainWindowWidth / columnWidth));

            var rowDefinition = new RowDefinition { Height = new GridLength(rowHeight) };
            RowDefinitions.Add(rowDefinition);

            for (var i = 0; i < columnCount; i++)
            {
                var columnDefinition = new ColumnDefinition { Width = new GridLength(columnWidth) };
                ColumnDefinitions.Add(columnDefinition);
            }

            foreach (var tower in MainWindow.Towers)
            {
                var label = new Label
                {
                    Content = tower.Name
                };

                Children.Add(label);
            }

            Visibility = Visibility.Hidden;
        }
    }
}