using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Constants;
using GameClient.GameObjects.Class.Factory;
using GameClient.GameObjects.GameViewCanvas;
using GameClient.GameObjects.Logger;
using GameClient.GameObjects.Tower;
using GameClient.HubClient;
using GameClient.HubClient.Chain;
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
        public static Border GameGridBorder { get; set; }
        public static Grid GameGrid { get; set; }
        public static Grid GameStats { get; set; }
        public static Grid TowerSelector { get; set; }

        public static Label HealthLabel { get; set; }
        public static Label MoneyLabel { get; set; }
        public static Label ClassLabel { get; set; }
        public static string ClassId { get; set; }

        public static List<IClass> Classes { get; set; }
        public static List<Tower> Towers { get; set; }

        public static HubConnection GameInfoHub { get; set; }

        public static IClass SelectedClass { get; set; }
        public static List<List<Label>> Map { get; set; }
        public static List<Button> TowerButtons { get; set; }

        public static int SelectedRow { get; set; }
        public static int SelectedColumn { get; set; }

        // ReSharper disable once MemberInitializerValueIgnored
        private readonly IGameViewCanvasFacade _gameViewCanvasFacade = GameViewCanvasFacade.Null;

        private Handler _chainHandler;

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
            RegisterChain();

            _gameViewCanvasFacade = new ActualGameViewCanvasFacade();
            _gameViewCanvasFacade.AddMainMenu();

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

        private void RegisterChain()
        {
            _chainHandler = new MoneyHandler();
            var healthHandler = new HealthHandler();
            var classNameHandler = new ClassNameHandler();
            var clientIdHandler = new ClientIdHandler();

            _chainHandler.SetNextType(healthHandler);
            healthHandler.SetNextType(classNameHandler);
            classNameHandler.SetNextType(clientIdHandler);
        }

        private void ClientHubConnection()
        {
            GameInfoHub = new HubConnectionBuilder()
                .WithUrl(HubConstants.GameHub)
                .Build();

            GameInfoHub.StartAsync();

            GameInfoHub.On<string, string, int, int, List<List<string>>>(HubConstants.RegisterReceive,
                (clientId, className, money, health, map) =>
                {
                    Dispatcher?.Invoke(() =>
                    {
                        SelectedClass = Classes.First(classObject => className == classObject.Type.ToString());

                        CompositeLogger.LogMessage($"{SelectedClass.Type.ToString()} {clientId}");

                        _gameViewCanvasFacade.AddTowers(SelectedClass);
                        _gameViewCanvasFacade.AddGameGrid(map);

                        GameViewCanvas.Children.Remove(MainMenu);
                        GameViewCanvas.Children.Remove(ClassSelectorMenu);

                        _chainHandler.HandleRequest(clientId, ClientItemType.ClientId);
                        _chainHandler.HandleRequest(SelectedClass.Type.ToString(), ClientItemType.ClassName);
                        _chainHandler.HandleRequest(money.ToString(), ClientItemType.Money);
                        _chainHandler.HandleRequest(health.ToString(), ClientItemType.Health);
                    });
                });

            GameInfoHub.On<List<string>>(HubConstants.ClassesReceive,
                list =>
                {
                    Dispatcher?.Invoke(() =>
                    {
                        _gameViewCanvasFacade.AddClasses(list);
                        _gameViewCanvasFacade.AddClassSelectorMenu();
                    });
                });

            GameInfoHub.On<List<List<string>>, int>(HubConstants.BuildTowerReceive,
                (map, money) =>
                {
                    Dispatcher?.Invoke(() =>
                    {
                        MoneyLabel.Content = money;
                        _gameViewCanvasFacade.PopulateGameGrid(map, GameGrid);
                    });
                });

            GameInfoHub.On(HubConstants.ResetGameReceive,
                () => { Dispatcher?.Invoke(() => { Application.Current.Shutdown(); }); });
        }
    }
}