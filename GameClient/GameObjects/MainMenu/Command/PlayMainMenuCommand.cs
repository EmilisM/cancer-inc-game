using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class PlayMainMenuCommand : ICommand
    {
        private readonly IMainMenuReceiver _receiver;

        public PlayMainMenuCommand(IMainMenuReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Play();
        }

        public void Undo()
        {
            _receiver.Exit();
        }
    }
}