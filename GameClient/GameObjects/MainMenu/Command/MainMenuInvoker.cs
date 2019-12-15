using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuInvoker
    {
        private readonly ICommand _playCommand;
        private readonly ICommand _exitCommand;
        private readonly ICommand _resetCommand;

        public MainMenuInvoker(ICommand playCommand, ICommand exitCommand, ICommand resetCommand)
        {
            _playCommand = playCommand;
            _exitCommand = exitCommand;
            _resetCommand = resetCommand;
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

        public void Reset()
        {
            _resetCommand.Execute();
            MainWindow.CompositeLogger.LogMessage("MainMenuInvoker Reset");
        }
    }
}