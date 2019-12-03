using Xunit;
using GameClient.GameObjects.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Threading;

namespace GameClient.GameObjects.Menu.Tests
{
    public class MenuButtonPrototypeTests
    {
        
        [Fact()]
        public void CloneExitButtonTest()
        {
            var thread1 = (new Thread(delegate ()
            {
                GameClient.GameObjects.MainMenuButton.ExitMainMenuButton exitButton = new MainMenuButton.ExitMainMenuButton();
                var cloned = exitButton.DeepClone();
                Assert.Equal(cloned, exitButton);
            }));
            thread1.SetApartmentState(ApartmentState.STA);
            thread1.Start();
            thread1.Join();

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