namespace GameClient.GameObjects.MainMenu.Command
{
    public interface IMainMenuReceiver
    {
        void Play();
        void Exit();

        void Show();
        void Hide();
    }
}