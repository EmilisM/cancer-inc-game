using GameClient.Helpers;

namespace GameClient.GameObjects.MainMenuButton
{
    public class ResetMainMenuButton : MainMenuButtonPrototype
    {
        public ResetMainMenuButton() : base(MainMenuButtonType.Reset)
        {
        }

        public override MainMenuButtonPrototype ShallowClone()
        {
            return MemberwiseClone() as ResetMainMenuButton;
        }

        public override MainMenuButtonPrototype DeepClone()
        {
            return XamlObjectHelper.DeepClone(this);
        }
    }
}