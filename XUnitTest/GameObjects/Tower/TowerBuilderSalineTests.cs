using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderSalineTests
    {
        [Fact()]
        public void BuildTowerTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderSaline builder = new GameClient.GameObjects.Tower.TowerBuilderSaline();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Saline";
            Assert.Equal(expected, tower.Name);
        }
    }
}