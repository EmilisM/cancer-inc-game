using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Api;
using GameClient.Constants;
using GameClient.GameObjects.Class.Factory;
using GameClient.GameObjects.GameViewCanvas;
using GameClient.GameObjects.Logger;
using Microsoft.AspNetCore.SignalR.Client;

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

        public static Grid GameUi { get; set; }
        public static Border GameGrid { get; set; }
        public static Grid GameStats { get; set; }

        public static Label HealthLabel { get; set; }
        public static Label MoneyLabel { get; set; }

        public static List<IClass> Classes { get; set; }

        public static HubConnection GameInfoHub { get; set; }

        private readonly GameViewCanvasFacade _gameViewCanvasFacade;


        public MainWindow()
        {
            InitializeComponent();

            GameCanvasRow = GameCanvasRowDefinition;
            GameViewCanvas = GameView;
            LoggerRow = LoggerRowDefinition;
            Logger = LoggerList;

            ClientHubConnection();
            InitializeMainWindow();
            InitializeGameViewCanvas();
            InitializeLogger();

            _gameViewCanvasFacade = new GameViewCanvasFacade();
            _gameViewCanvasFacade.AddGameObjects();

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

        private void ClientHubConnection()
        {
            GameInfoHub = new HubConnectionBuilder()
                .WithUrl(HubConstants.GameHub)
                .Build();

            GameInfoHub.StartAsync();

            GameInfoHub.On<string>(HubConstants.RegisterReceive,
                clientId =>
                {
                    Dispatcher?.Invoke(() =>
                    {
                        CompositeLogger.LogMessage(clientId);
                    });
                });

            GameInfoHub.On<List<string>>(HubConstants.ClassesReceive,
                list =>
                {
                    Dispatcher?.Invoke(() =>
                    {
                        _gameViewCanvasFacade.AddClasses(list);
                        _gameViewCanvasFacade.AddGameMenu();
                    });
                });
        }
    }
}