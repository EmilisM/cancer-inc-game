using Xunit;
using GameClient.GameObjects.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GameClient.GameObjects.Menu.Tests
{
    public class MenuCreatorTemplateTests
    {
        [Fact()]
        public void CreateMainMenuTest()
        {
            GameClient.GameObjects.Menu.MenuCreatorTemplate template = new GameClient.GameObjects.MainMenu.MainMenuCreator();
            var expected = template.CreateMenu();
            Assert.NotNull(expected);
        }

        [Fact()]
        public void CreateClassSelectorMenuTest()
        {
                GameClient.GameObjects.Menu.MenuCreatorTemplate template = new GameClient.GameObjects.ClassSelectorMenu.ClassSelectorMenuCreator();
                var expected = template.CreateMenu();
                Assert.NotNull(expected);
        }
    }
}