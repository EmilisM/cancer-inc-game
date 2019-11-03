using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuInvoker
    {
        private readonly ICommand _playCommand;
        private readonly ICommand _exitCommand;
        private readonly ICommand _hideCommand;
        private readonly ICommand _showCommand;

        public MainMenuInvoker(ICommand playCommand, ICommand exitCommand, ICommand hideCommand, ICommand showCommand)
        {
            _playCommand = playCommand;
            _exitCommand = exitCommand;
            _hideCommand = hideCommand;
            _showCommand = showCommand;
        }

        public void Play()
        {
            _playCommand.Execute();
        }

        public void Exit()
        {
            _exitCommand.Execute();
        }

        public void Show()
        {
            _showCommand.Execute();
        }

        public void Hide()
        {
            _hideCommand.Execute();
        }
    }
}