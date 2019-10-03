using System.Windows.Media;

namespace GameClient
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            GameView.Background = Brushes.Black;
        }
    }
}
