using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GameClient.GameObjects.MainMenu.Prototype;

namespace GameClient.GameObjects.MainMenu.Service
{
    public interface IMainMenuService
    {
        Grid CreateMainMenu(List<MainMenuButtonPrototype> buttons, UIElement title);
    }
}