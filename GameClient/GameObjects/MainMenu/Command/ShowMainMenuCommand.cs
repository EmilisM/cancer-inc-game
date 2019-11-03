using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class ShowMainMenuCommand : ICommand
    {
        private readonly IMainMenuReceiver _receiver;

        public ShowMainMenuCommand(IMainMenuReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Show();
        }
    }
}
