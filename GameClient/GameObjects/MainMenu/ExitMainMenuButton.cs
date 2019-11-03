using GameClient.GameObjects.MainMenu.Prototype;

namespace GameClient.GameObjects.MainMenu
{
    public class ExitMainMenuButton : MainMenuButtonPrototype
    {
        public ExitMainMenuButton() : base("Exit")
        {
        }

        public override MainMenuButtonPrototype ShallowClone()
        {
            throw new System.NotImplementedException();
        }

        public override MainMenuButtonPrototype DeepClone()
        {
            throw new System.NotImplementedException();
        }
    }
}