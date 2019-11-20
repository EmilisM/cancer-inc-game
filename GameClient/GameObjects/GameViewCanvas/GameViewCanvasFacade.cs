using GameClient.GameObjects.ClassSelectorMenu;
using GameClient.GameObjects.MainMenu;
using GameClient.GameObjects.Menu;

namespace GameClient.GameObjects.GameViewCanvas
{
    public class GameViewCanvasFacade
    {
        private readonly MenuCreatorTemplate _mainMenuCreator;
        private readonly MenuCreatorTemplate _classSelectorMenuCreator;

        public GameViewCanvasFacade()
        {
            _mainMenuCreator = new MainMenuCreator();
            _classSelectorMenuCreator = new ClassSelectorMenuCreator();
        }

        public void AddGameObjects()
        {
            var mainMenu = _mainMenuCreator.CreateMenu();
            var classSelectorMenu = _classSelectorMenuCreator.CreateMenu();

            MainWindow.GameViewCanvas.Children.Add(mainMenu);
            MainWindow.GameViewCanvas.Children.Add(classSelectorMenu);

            MainWindow.MainMenu = mainMenu;
            MainWindow.ClassSelectorMenu = classSelectorMenu;
        }
    }
}