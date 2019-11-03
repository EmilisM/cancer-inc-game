using GameClient.Command;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class HideMainMenuCommand : ICommand
    {
        private readonly IMainMenuReceiver _mainMenuReceiver;

        public HideMainMenuCommand(IMainMenuReceiver mainMenuReceiver)
        {
            _mainMenuReceiver = mainMenuReceiver;
        }

        public void Execute()
        {
            _mainMenuReceiver.Hide();
        }
    }
}
