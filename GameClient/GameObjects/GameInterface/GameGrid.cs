using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameClient.Constants;

namespace GameClient.GameObjects.GameInterface
{
    public sealed class GameGrid : Border
    {
        public GameGrid(List<List<string>> map)
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

            MainWindow.Map = new List<List<Label>>();

            for (var i = 0; i < map.Count; i++)
            {
                var row = new List<Label>();
                for (var j = 0; j < map[i].Count; j++)
                {
                    var label = new Label();
                    row.Add(label);

                    label.Background = map[i][j] == "Free"
                        ? new SolidColorBrush(Color.FromRgb(18, 38, 59))
                        : Brushes.Black;

                    label.SetValue(Grid.RowProperty, i);
                    label.SetValue(Grid.ColumnProperty, j);

                    var i1 = i;
                    var j1 = j;
                    label.MouseLeftButtonDown += (sender, args) => LabelOnMouseLeftButtonDown(sender, args, i1, j1);

                    gameGrid.Children.Add(label);
                }

                MainWindow.Map.Add(row);
            }

            BorderBrush = Brushes.DarkGray;
            BorderThickness = new Thickness(2);
            gameGrid.ShowGridLines = true;

            Child = gameGrid;
        }

        private void LabelOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e, int row, int column)
        {
            MainWindow.GameStats.Visibility = Visibility.Hidden;
            MainWindow.TowerSelector.Visibility = Visibility.Visible;
        }
    }
}