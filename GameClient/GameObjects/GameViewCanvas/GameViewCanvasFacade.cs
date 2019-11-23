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
        private readonly MenuCreatorTemplate _classSelectorMenuCreator;

        private readonly ClassFactory _classFactory;

        public GameViewCanvasFacade()
        {
            _classFactory = new ClassFactory();
            _mainMenuCreator = new MainMenuCreator();
            _classSelectorMenuCreator = new ClassSelectorMenuCreator();
        }

        public void AddApiGameObjects()
        {
            var classes = _classFactory.GetClasses();

            MainWindow.Classes = classes;
        } 

        public void AddGameObjects()
        {
            var mainMenu = _mainMenuCreator.CreateMenu();
            var classSelectorMenu = _classSelectorMenuCreator.CreateMenu();

            var gameStats = new GameStats();
            var gameGrid = new GameGrid();
            var gameUi = new GameUi(gameStats, gameGrid);

            MainWindow.GameViewCanvas.Children.Add(mainMenu);
            MainWindow.GameViewCanvas.Children.Add(classSelectorMenu);
            MainWindow.GameViewCanvas.Children.Add(gameUi);

            MainWindow.MainMenu = mainMenu;
            MainWindow.ClassSelectorMenu = classSelectorMenu;
            MainWindow.GameUi = gameUi;
            MainWindow.GameStats = gameStats;
            MainWindow.GameGrid = gameGrid;
        }
    }
}