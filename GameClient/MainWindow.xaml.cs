using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.GameObjects.GameViewCanvas;
using GameClient.GameObjects.Logger;

namespace GameClient
{
    public partial class MainWindow
    {
        public static CompositeLogger CompositeLogger { get; private set; }

        public static Canvas GameViewCanvas { get; private set; }
        public static ListBox Logger { get; private set; }

        public static Grid MainMenu { get; set; }
        public static Grid ClassSelectorMenu { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            GameView.Background = Brushes.Black;

            GameViewCanvas = GameView;
            Logger = LoggerList;

            InitializeLogger();

            var gameViewCanvasFacade = new GameViewCanvasFacade();
            gameViewCanvasFacade.AddGameObjects();

            MainMenu.Visibility = Visibility.Visible;
        }

        private static void InitializeLogger()
        {
            CompositeLogger = new CompositeLogger(new List<ILogger>
            {
                new ConsoleLogger()
            });
        }
    }
}