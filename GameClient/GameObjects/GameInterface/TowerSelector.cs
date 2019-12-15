using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Constants;
using GameClient.HubClient;
using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.GameObjects.GameInterface
{
    public class TowerSelector : Grid
    {
        public TowerSelector()
        {
            const int rowHeight = 48;

            var columnCount = Convert.ToInt32(Math.Floor(GameConstants.MainWindowWidth / MainWindow.Towers.Count));

            var rowDefinition = new RowDefinition { Height = new GridLength(rowHeight) };
            RowDefinitions.Add(rowDefinition);

            var columnWidth = GameConstants.MainWindowWidth / MainWindow.Towers.Count;

            for (var i = 0; i < columnCount; i++)
            {
                var columnDefinition = new ColumnDefinition { Width = new GridLength(columnWidth) };
                ColumnDefinitions.Add(columnDefinition);
            }

            MainWindow.TowerButtons = new List<Button>();

            var index = 0;
            foreach (var tower in MainWindow.Towers)
            {
                var button = new Button
                {
                    Content = $"{tower.Name} {tower.Cost}",
                    Background = Brushes.Black,
                    Foreground = Brushes.White
                };

                button.Click += (sender, args) =>
                {
                    MainWindow.GameInfoHub.InvokeAsync(HubConstants.BuildTower, tower.Name, tower.Cost,
                        MainWindow.SelectedRow,
                        MainWindow.SelectedColumn);

                    MainWindow.Map[MainWindow.SelectedRow][MainWindow.SelectedColumn].Background = new SolidColorBrush(Color.FromRgb(18, 38, 59));

                    MainWindow.TowerSelector.Visibility = Visibility.Hidden;
                    MainWindow.GameStats.Visibility = Visibility.Visible;
                };

                button.SetValue(ColumnProperty, index);
                index++;

                Children.Add(button);
                MainWindow.TowerButtons.Add(button);
            }

            Visibility = Visibility.Hidden;
        }
    }
}