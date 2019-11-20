using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuInvoker
    {
        private readonly ICommand _playCommand;
        private readonly ICommand _exitCommand;

        public MainMenuInvoker(ICommand playCommand, ICommand exitCommand)
        {
            _playCommand = playCommand;
            _exitCommand = exitCommand;
        }

        public void Play()
        {
            _playCommand.Execute();
            MainWindow.CompositeLogger.LogMessage("MainMenuInvoker Play");
        }

        public void Exit()
        {
            _exitCommand.Execute();
            MainWindow.CompositeLogger.LogMessage("MainMenuInvoker Exit");
        }
    }
}