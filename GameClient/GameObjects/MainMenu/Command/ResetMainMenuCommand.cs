using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class ResetMainMenuCommand : ICommand
    {
        private readonly IMainMenuReceiver _receiver;

        public ResetMainMenuCommand(IMainMenuReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Reset();
        }

        public void Undo()
        {
            _receiver.Exit();
        }
    }
}