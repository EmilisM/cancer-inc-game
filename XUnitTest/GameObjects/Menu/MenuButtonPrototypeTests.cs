using Xunit;
using GameClient.GameObjects.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GameClient.GameObjects.Menu.Tests
{
    public class MenuButtonPrototypeTests
    {
        [Fact()]
        public void CloneExitButtonTest()
        {
            GameClient.GameObjects.MainMenuButton.ExitMainMenuButton exitButton = new MainMenuButton.ExitMainMenuButton();

            var cloned = exitButton.DeepClone();
            Assert.Equal(cloned, exitButton);
        }

        [Fact()]
        public void ClonePlayButtonTest()
        {
            GameClient.GameObjects.MainMenuButton.PlayMainMenuButton exitButton = new MainMenuButton.PlayMainMenuButton();

            var cloned = exitButton.DeepClone();
            Assert.Equal(cloned, exitButton);
        }
    }
}