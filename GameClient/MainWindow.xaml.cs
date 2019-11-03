using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.Class;
using GameClient.GameObjects.Logger;
using GameClient.GameObjects.MainMenu.Command;
using GameClient.GameObjects.MainMenu.Facade;
using GameClient.GameObjects.Types;

namespace GameClient
{
    public partial class MainWindow
    {
        private MainMenuInvoker _mainMenuInvoker;
        private MainMenuFacade _mainMenuFacade;

        public static CompositeLogger CompositeLogger;

        public static Canvas GameViewCanvas { get; private set; }
        public static ListBox LogList { get; private set; }
        public static UIElement MainMenu { get; private set; }

        public static List<IClass> Classes;

        public MainWindow()
        {
            InitializeComponent();
            GameViewCanvas = GameView;
            LogList = LoggerList;

            InitializeCommands();
            InitializeLogger();

            GameViewCanvas.Background = Brushes.Black;

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            ShowMainMenu();

            var classFactory = new ClassFactory();

            Classes = new List<IClass>
            {
                classFactory.GetClass(ClassType.White),
                classFactory.GetClass(ClassType.Red),
                classFactory.GetClass(ClassType.Yellow),
                classFactory.GetClass(ClassType.Green)
            };


        }

        private static void InitializeLogger()
        {
            CompositeLogger = new CompositeLogger(new List<ILogger>
            {
                new ConsoleLogger()
            });
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