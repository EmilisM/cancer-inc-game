using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GameClient.Constants;

namespace GameClient.GameObjects.GameInterface
{
    public sealed class GameGrid : Border
    {
        public GameGrid()
        {
            var gameGrid = new Grid();

            for (var i = 0; i < GameConstants.Rows; i++)
            {
                var rowDefinition = new RowDefinition { Height = new GridLength(GameConstants.RowHeight) };
                gameGrid.RowDefinitions.Add(rowDefinition);
            }

            for (var i = 0; i < GameConstants.Columns; i++)
            {
                var columnDefinition = new ColumnDefinition { Width = new GridLength(GameConstants.ColumnWidth) };
                gameGrid.ColumnDefinitions.Add(columnDefinition);
            }

            BorderBrush = Brushes.DarkGray;
            BorderThickness = new Thickness(2);
            gameGrid.ShowGridLines = true;

            var brush = new ImageBrush();
            var image = new Image { Source = new BitmapImage(new Uri("Resources/background.jpg", UriKind.Relative)) };

            brush.ImageSource = image.Source;

            gameGrid.Background = brush;

            Child = gameGrid;
        }
    }
}