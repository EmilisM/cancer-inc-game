using System.Windows;
using System.Windows.Controls;
using GameClient.Constants;
using GameClient.Visitor;

namespace GameClient.GameObjects.GameInterface
{
    public sealed class GameUi : Grid
    {
        public GameUi(GameStats gameStats, GameGrid gameGrid, TowerSelector towerSelector)
        {
            var gameColumnDefinition = new ColumnDefinition
                { Width = new GridLength(GameConstants.MainWindowWidth - 16) };

            var gameGridDefinition = new RowDefinition
                { Height = new GridLength(GameConstants.GameViewCanvasHeight - 48) };
            var gameStatsDefinition = new RowDefinition { Height = new GridLength(48) };

            ColumnDefinitions.Add(gameColumnDefinition);

            RowDefinitions.Add(gameGridDefinition);
            RowDefinitions.Add(gameStatsDefinition);

            var structure = new ObjectStructure();
            structure.Attach(towerSelector);
            structure.Attach(gameStats);
            structure.Attach(gameGrid);

            towerSelector.ParentNode = this;
            gameStats.ParentNode = this;
            gameGrid.ParentNode = this;

            structure.Accept(new VisitorRowProperty());
            structure.Accept(new VisitorAddChild());

            Visibility = Visibility.Visible;
        }
    }
}