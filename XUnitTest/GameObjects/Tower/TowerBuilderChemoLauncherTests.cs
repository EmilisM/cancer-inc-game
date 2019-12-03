using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderChemoLauncherTests
    {
        [Fact()]
        public void TowerBuilderChemoLauncherTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderChemoLauncher builder = new GameClient.GameObjects.Tower.TowerBuilderChemoLauncher();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Chemo launcher";
            Assert.Equal(expected, tower.Name);
        }

    }
}