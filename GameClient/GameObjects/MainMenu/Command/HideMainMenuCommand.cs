using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class HideMainMenuCommand : ICommand
    {
        private readonly IMainMenuReceiver _receiver;

        public HideMainMenuCommand(IMainMenuReceiver mainMenuReceiver)
        {
            _receiver = mainMenuReceiver;
        }

        public void Execute()
        {
            _receiver.Hide();
        }

        public void Undo()
        {
            _receiver.Show();
        }
    }
}
