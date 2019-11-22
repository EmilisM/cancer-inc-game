using System.Windows;
using System.Windows.Controls;
using GameClient.Constants;

namespace GameClient.GameObjects.GameInterface
{
    public sealed class GameUi : Grid
    {
        public GameUi(UIElement gameStats, UIElement gameGrid)
        {
            var gameColumnDefinition = new ColumnDefinition { Width = new GridLength(GameConstants.MainWindowWidth - 16) };

            var gameGridDefinition = new RowDefinition
                { Height = new GridLength(GameConstants.GameViewCanvasHeight - 48) };
            var gameStatsDefinition = new RowDefinition { Height = new GridLength(48) };

            ColumnDefinitions.Add(gameColumnDefinition);

            RowDefinitions.Add(gameGridDefinition);
            RowDefinitions.Add(gameStatsDefinition);

            gameGrid.SetValue(RowProperty, 0);
            gameStats.SetValue(RowProperty, 1);

            Children.Add(gameGrid);
            Children.Add(gameStats);

            Visibility = Visibility.Hidden;
        }
    }
}