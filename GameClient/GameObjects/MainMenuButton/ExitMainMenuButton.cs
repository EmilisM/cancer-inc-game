using GameClient.Helpers;

namespace GameClient.GameObjects.MainMenuButton
{
    public class ExitMainMenuButton : MainMenuButtonPrototype
    {
        public ExitMainMenuButton() : base(MainMenuButtonType.Exit)
        {
        }

        public override MainMenuButtonPrototype ShallowClone()
        {
            return MemberwiseClone() as ExitMainMenuButton;
        }

        public override MainMenuButtonPrototype DeepClone()
        {
            return XamlObjectHelper.DeepClone(this);
        }
    }
}