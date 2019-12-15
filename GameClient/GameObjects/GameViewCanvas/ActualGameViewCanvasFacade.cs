using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameClient.Constants;
using GameClient.GameObjects.Class.Factory;
using GameClient.GameObjects.ClassSelectorMenu;
using GameClient.GameObjects.GameInterface;
using GameClient.GameObjects.MainMenu;
using GameClient.GameObjects.Menu;
using GameClient.GameObjects.Tower;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.GameViewCanvas
{
    public class ActualGameViewCanvasFacade : IGameViewCanvasFacade
    {
        private readonly MenuCreatorTemplate _mainMenuCreator;
        private readonly ClassFactory _classFactory;
        private readonly MenuCreatorTemplate _classSelectorMenuCreator;
        private readonly TowerDirector _towerDirector;

        public ActualGameViewCanvasFacade()
        {
            _towerDirector = new TowerDirector();
            _classSelectorMenuCreator = new ClassSelectorMenuCreator();
            _classFactory = new ClassFactory();
            _mainMenuCreator = new MainMenuCreator();
        }

        public void AddClasses(List<string> exceptList)
        {
            var classes = _classFactory.GetClasses(exceptList);

            MainWindow.Classes = classes;
        }

        public void AddTowers(IClass selectedClass)
        {
            var towers = new List<Tower.Tower>
            {
                _towerDirector.Construct(new TowerBuilderBazooka()),
                _towerDirector.Construct(new TowerBuilderSaline()),
                _towerDirector.Construct(new TowerBuilderBoomerang()),
                _towerDirector.Construct(new TowerBuilderCannon()),
                _towerDirector.Construct(new TowerBuilderChemoLauncher()),
                _towerDirector.Construct(new TowerBuilderCoinMiner()),
                _towerDirector.Construct(new TowerBuilderCrossbow()),
                _towerDirector.Construct(new TowerBuilderLaser()),
                _towerDirector.Construct(new TowerBuilderRadar()),
                _towerDirector.Construct(new TowerBuilderSlingshot()),
                _towerDirector.Construct(new TowerBuilderTurret())
            };

            MainWindow.Towers = towers
                .Where(tower => tower.ClassType == ClassType.All || tower.ClassType == selectedClass.Type).ToList();
        }

        public void AddClassSelectorMenu()
        {
            var classSelectorMenu = _classSelectorMenuCreator.CreateMenu();

            MainWindow.ClassSelectorMenu = classSelectorMenu;
            MainWindow.GameViewCanvas.Children.Add(classSelectorMenu);
        }

        public void AddMainMenu()
        {
            var mainMenu = _mainMenuCreator.CreateMenu();

            MainWindow.MainMenu = mainMenu;
            MainWindow.GameViewCanvas.Children.Add(mainMenu);
        }

        public void PopulateGameGrid(List<List<string>> map, Grid grid)
        {
            MainWindow.Map = new List<List<Label>>();

            MainWindow.SelectedRow = -1;
            MainWindow.SelectedColumn = -1;

            for (var i = 0; i < map.Count; i++)
            {
                var row = new List<Label>();
                for (var j = 0; j < map[i].Count; j++)
                {
                    var label = new Label();
                    row.Add(label);

                    label.Background = map[i][j] == "Free"
                        ? Brushes.Transparent
                        : GameConstants.OccupiedColor;

                    if (map[i][j] != "Free")
                    {
                        label.Content = map[i][j];
                    }

                    label.SetValue(Grid.RowProperty, i);
                    label.SetValue(Grid.ColumnProperty, j);

                    var i1 = i;
                    var j1 = j;
                    label.MouseLeftButtonDown += (sender, args) => LabelOnMouseLeftButtonDown(sender, args, i1, j1);

                    grid.Children.Add(label);
                }

                MainWindow.Map.Add(row);
            }
        }

        private void LabelOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e, int row, int column)
        {
            if (MainWindow.Map[row][column].Background == Brushes.Blue)
            {
                return;
            }

            if (MainWindow.SelectedRow == row && MainWindow.SelectedColumn == column)
            {
                MainWindow.Map[MainWindow.SelectedRow][MainWindow.SelectedColumn].Background =
                    new SolidColorBrush();

                MainWindow.SelectedRow = -1;
                MainWindow.SelectedColumn = -1;

                MainWindow.GameStats.Visibility = Visibility.Visible;
                MainWindow.TowerSelector.Visibility = Visibility.Hidden;
                return;
            }

            if (row >= 0 && column >= 0)
            {
                if (MainWindow.SelectedColumn >= 0 && MainWindow.SelectedRow >= 0)
                {
                    MainWindow.Map[MainWindow.SelectedRow][MainWindow.SelectedColumn].Background =
                        new SolidColorBrush();
                }

                MainWindow.SelectedColumn = column;
                MainWindow.SelectedRow = row;

                MainWindow.Map[row][column].Background = GameConstants.SelectColor;

                MainWindow.GameStats.Visibility = Visibility.Hidden;
                MainWindow.TowerSelector.Visibility = Visibility.Visible;
            }
        }

        public void AddGameGrid(List<List<string>> map)
        {
            var towerSelector = new TowerSelector();
            var gameStats = new GameStats();
            var gameGrid = new GameGrid();

            PopulateGameGrid(map, (Grid) gameGrid.Child);
            var gameUi = new GameUi(gameStats, gameGrid, towerSelector);

            MainWindow.GameViewCanvas.Children.Add(gameUi);

            MainWindow.GameUi = gameUi;
            MainWindow.GameStats = gameStats;
            MainWindow.GameGridBorder = gameGrid;
            MainWindow.GameGrid = (Grid) gameGrid.Child;
            MainWindow.TowerSelector = towerSelector;
        }
    }
}