using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.MainMenu.Command;
using GameClient.GameObjects.MainMenuButton;
using GameClient.GameObjects.Menu;

namespace GameClient.GameObjects.MainMenu
{
    public class MainMenuCreator : MenuCreatorTemplate
    {
        protected override GameObjectName GetObjectName()
        {
            return GameObjectName.MainMenu;
        }

        protected override Label CreateMenuTitle()
        {
            var title = new Label
            {
                Name = GameObjectName.MainMenuTitle.ToString(),
                Foreground = Brushes.White,
                Content = "Cancer tower defense",
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return title;
        }

        protected override List<Button> CreateMenuButtons()
        {
            var receiver = new MainMenuReceiver();
            var playCommand = new PlayMainMenuCommand(receiver);
            var exitCommand = new ExitMainMenuCommand(receiver);
            var resetCommand = new ResetMainMenuCommand(receiver);

            var invoker = new MainMenuInvoker(playCommand, exitCommand, resetCommand);

            var exitMainMenuButton = new ExitMainMenuButton();
            exitMainMenuButton.Click += (sender, args) => invoker.Exit();

            var playMainMenuButton = new PlayMainMenuButton();
            playMainMenuButton.Click += (sender, args) => invoker.Play();

            var resetMainMenuButton = new ResetMainMenuButton();
            resetMainMenuButton.Click += (sender, args) => invoker.Reset();

            return new List<Button>
            {
                playMainMenuButton,
                resetMainMenuButton,
                exitMainMenuButton
            };
        }
    }
}