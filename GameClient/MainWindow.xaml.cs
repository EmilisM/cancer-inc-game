using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.MainMenu.Command;
using GameClient.GameObjects.MainMenu.Facade;

namespace GameClient
{
    public partial class MainWindow
    {
        private MainMenuInvoker _mainMenuInvoker;
        private MainMenuFacade _mainMenuFacade;

        public static Canvas GameViewCanvas { get; private set; }
        public static ListBox LogList { get; private set; }

        public static UIElement MainMenu { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            GameViewCanvas = GameView;
            LogList = LoggerList;

            InitializeCommands();

            GameViewCanvas.Background = Brushes.Black;

            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            _mainMenuFacade = new MainMenuFacade(_mainMenuInvoker);
            MainMenu = _mainMenuFacade.GetMainMenu();

            GameViewCanvas.Children.Add(MainMenu);

            _mainMenuInvoker.Show();
        }

        private void InitializeCommands()
        {
            var receiver = new MainMenuReceiver();
            var playCommand = new PlayMainMenuCommand(receiver);
            var exitCommand = new ExitMainMenuCommand(receiver);
            var hideCommand = new HideMainMenuCommand(receiver);
            var showCommand = new ShowMainMenuCommand(receiver);

            _mainMenuInvoker = new MainMenuInvoker(playCommand, exitCommand, hideCommand, showCommand);
        }
    }
}