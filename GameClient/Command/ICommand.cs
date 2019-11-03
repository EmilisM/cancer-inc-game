namespace GameClient.Command
{
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}