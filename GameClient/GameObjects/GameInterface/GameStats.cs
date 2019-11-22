using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Constants;

namespace GameClient.GameObjects.GameInterface
{
    public class GameStats : Grid
    {
        public GameStats()
        {
            var rowDefinition = new RowDefinition { Height = new GridLength(48) };

            RowDefinitions.Add(rowDefinition);

            for (var i = 0; i < 3; i++)
            {
                var columnDefinition = new ColumnDefinition
                    { Width = new GridLength(GameConstants.MainWindowWidth / 3) };

                ColumnDefinitions.Add(columnDefinition);
            }

            MainWindow.HealthLabel = new Label
            {
                Content = 100, Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                ContentStringFormat = "Health {0}"
            };
            MainWindow.HealthLabel.SetValue(ColumnProperty, 0);

            MainWindow.MoneyLabel = new Label
            {
                Content = 0, Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                ContentStringFormat = "Money {0}"
            };
            MainWindow.MoneyLabel.SetValue(ColumnProperty, 1);

            Children.Add(MainWindow.HealthLabel);
            Children.Add(MainWindow.MoneyLabel);
        }
    }
}