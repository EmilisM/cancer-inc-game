using System.Collections.Generic;
using GameClient.GameObjects.Class.Factory;
using GameClient.GameObjects.ClassSelectorMenu;
using GameClient.GameObjects.GameInterface;
using GameClient.GameObjects.MainMenu;
using GameClient.GameObjects.Menu;

namespace GameClient.GameObjects.GameViewCanvas
{
    public class GameViewCanvasFacade
    {
        private readonly MenuCreatorTemplate _mainMenuCreator;
        private readonly ClassFactory _classFactory;
        private readonly MenuCreatorTemplate _classSelectorMenuCreator;

        public GameViewCanvasFacade()
        {
            _classSelectorMenuCreator = new ClassSelectorMenuCreator();
            _classFactory = new ClassFactory();
            _mainMenuCreator = new MainMenuCreator();
        }

        public void AddClasses(List<string> exceptList)
        {
            var classes = _classFactory.GetClasses(exceptList);

            MainWindow.Classes = classes;
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

        public void AddGameGrid()
        {
            var gameStats = new GameStats();
            var gameGrid = new GameGrid();
            var gameUi = new GameUi(gameStats, gameGrid);

            MainWindow.GameViewCanvas.Children.Add(gameUi);

            MainWindow.GameUi = gameUi;
            MainWindow.GameStats = gameStats;
            MainWindow.GameGrid = gameGrid;
        }
    }
}