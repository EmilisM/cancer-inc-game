using System.Windows.Media;
using GameClient.GameObjects.Tower;

namespace GameClient
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            GameView.Background = Brushes.Black;

            var builder = new SalineTowerBuilder();

            var director = new TowerDirector();

            var tower = director.Construct(builder);
        }
    }
}
