using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Constants;

namespace GameClient.GameObjects.GameInterface
{
    public sealed class GameGrid : Border
    {
        public GameGrid()
        {
            var gameGrid = new Grid();

            const int rowHeight = 48;
            const int columnWidth = 48;

            var rowCount = Convert.ToInt32(Math.Floor(GameConstants.GameViewCanvasHeight / rowHeight)) - 1;
            var columnCount = Convert.ToInt32(Math.Floor(GameConstants.MainWindowWidth / columnWidth));

            for (var i = 0; i < rowCount; i++)
            {
                var rowDefinition = new RowDefinition { Height = new GridLength(rowHeight) };
                gameGrid.RowDefinitions.Add(rowDefinition);
            }

            for (var i = 0; i < columnCount; i++)
            {
                var columnDefinition = new ColumnDefinition { Width = new GridLength(columnWidth) };
                gameGrid.ColumnDefinitions.Add(columnDefinition);
            }

            BorderBrush = Brushes.DarkGray;
            BorderThickness = new Thickness(2);

            Child = gameGrid;
        }
    }
}