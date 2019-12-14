using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using GameClient.GameObjects.Class.Factory;
using GameClient.GameObjects.ClassSelectorMenu;
using GameClient.GameObjects.GameInterface;
using GameClient.GameObjects.MainMenu;
using GameClient.GameObjects.Menu;
using GameClient.GameObjects.Tower;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.GameViewCanvas
{
    public class GameViewCanvasFacade
    {
        private readonly MenuCreatorTemplate _mainMenuCreator;
        private readonly ClassFactory _classFactory;
        private readonly MenuCreatorTemplate _classSelectorMenuCreator;
        private readonly TowerDirector _towerDirector;

        public GameViewCanvasFacade()
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

        public static void AddGameGrid(List<List<string>> map)
        {
            var towerSelector = new TowerSelector();
            var gameStats = new GameStats();
            var gameGrid = new GameGrid(map);
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