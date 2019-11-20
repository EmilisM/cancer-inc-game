using GameClient.Helpers;

namespace GameClient.GameObjects.MainMenuButton
{
    public class PlayMainMenuButton : MainMenuButtonPrototype
    {
        public PlayMainMenuButton() : base("Play")
        {
        }

        public override MainMenuButtonPrototype ShallowClone()
        {
            return MemberwiseClone() as PlayMainMenuButton;
        }

        public override MainMenuButtonPrototype DeepClone()
        {
            return XamlObjectHelper.DeepClone(this);
        }
    }
}