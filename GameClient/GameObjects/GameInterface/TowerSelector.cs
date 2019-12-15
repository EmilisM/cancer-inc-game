using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Constants;
using GameClient.HubClient;
using GameClient.HubClient.Interpreter;
using GameClient.Visitor;

namespace GameClient.GameObjects.GameInterface
{
    public class TowerSelector : Grid, IElement
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
                    MainWindow.InvokeActions(new InvokeContext
                    {
                        Action = HubConstants.BuildTower,
                        TowerName = tower.Name,
                        TowerCost = tower.Cost
                    });

                    MainWindow.Map[MainWindow.SelectedRow][MainWindow.SelectedColumn].Background =
                        new SolidColorBrush(Color.FromRgb(18, 38, 59));

                    MainWindow.TowerSelector.Visibility = Visibility.Hidden;
                    MainWindow.GameStats.Visibility = Visibility.Visible;
                };

                button.SetValue(ColumnProperty, index);
                index++;

                Children.Add(button);
                MainWindow.TowerButtons.Add(button);
            }

            Visibility = Visibility.Hidden;

            RowPropertyValue = 1;
        }

        public void Accept(Visitor.Visitor visitor)
        {
            visitor.Visit(this);
        }

        public int RowPropertyValue { get; set; }
        public UIElement ParentNode { get; set; }
    }
}