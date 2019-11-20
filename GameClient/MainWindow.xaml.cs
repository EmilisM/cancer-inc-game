using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Constants;
using GameClient.GameObjects.GameViewCanvas;
using GameClient.GameObjects.Logger;

namespace GameClient
{
    public partial class MainWindow
    {
        public static CompositeLogger CompositeLogger { get; private set; }

        private static RowDefinition LoggerRow { get; set; }
        private static RowDefinition GameCanvasRow { get; set; }

        public static Canvas GameViewCanvas { get; private set; }
        public static ListBox Logger { get; private set; }

        public static Grid MainMenu { get; set; }
        public static Grid ClassSelectorMenu { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            GameCanvasRow = GameCanvasRowDefinition;
            GameViewCanvas = GameView;
            LoggerRow = LoggerRowDefinition;
            Logger = LoggerList;

            InitializeMainWindow();
            InitializeGameViewCanvas();
            InitializeLogger();

            var gameViewCanvasFacade = new GameViewCanvasFacade();
            gameViewCanvasFacade.AddGameObjects();

            MainMenu.Visibility = Visibility.Visible;
        }

        private void InitializeMainWindow()
        {
            Height = GameConstants.MainWindowHeight;
            Width = GameConstants.MainWindowWidth;
        }

        private static void InitializeGameViewCanvas()
        {
            GameCanvasRow.Height = new GridLength(GameConstants.GameViewCanvasHeight);

            GameViewCanvas.Height = GameConstants.GameViewCanvasHeight;
            GameViewCanvas.Background = Brushes.Black;
        }

        private static void InitializeLogger()
        {
            LoggerRow.Height = new GridLength(GameConstants.LoggerRowDefinition);
            Logger.Height = GameConstants.LoggerHeight;

            CompositeLogger = new CompositeLogger(new List<ILogger>
            {
                new ConsoleLogger()
            });
        }
    }
}