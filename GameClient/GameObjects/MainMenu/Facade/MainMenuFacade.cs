using System.Collections.Generic;
using System.Windows;
using GameClient.GameObjects.MainMenu.Command;
using GameClient.GameObjects.MainMenu.Prototype;
using GameClient.GameObjects.MainMenu.Service;

namespace GameClient.GameObjects.MainMenu.Facade
{
    public class MainMenuFacade
    {
        private readonly IMainMenuTitleService _titleService;
        private readonly IMainMenuService _mainMenuService;

        private readonly MainMenuInvoker _mainMenuInvoker;

        public MainMenuFacade(MainMenuInvoker mainMenuInvoker)
        {
            _mainMenuInvoker = mainMenuInvoker;

            _mainMenuService = new MainMenuService();
            _titleService = new MainMenuTitleService();
        }

        public UIElement GetMainMenu()
        {
            var playButton = new PlayMainMenuButton();
            playButton.Click += (sender, args) => _mainMenuInvoker.Play();

            var exitButton = new ExitMainMenuButton();
            exitButton.Click += (sender, args) => _mainMenuInvoker.Exit();

            var buttons = new List<MainMenuButtonPrototype>
            {
                playButton,
                exitButton
            };

            var title = _titleService.GetMainMenuTitle();

            var mainMenu = _mainMenuService.CreateMainMenu(buttons, title);

            return mainMenu;
        }
    }
}