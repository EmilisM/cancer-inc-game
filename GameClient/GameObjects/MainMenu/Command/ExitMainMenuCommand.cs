using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class ExitMainMenuCommand : ICommand
    {
        private readonly IMainMenuReceiver _receiver;

        public ExitMainMenuCommand(IMainMenuReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Exit();
        }

        public void Undo()
        {
        }
    }
}