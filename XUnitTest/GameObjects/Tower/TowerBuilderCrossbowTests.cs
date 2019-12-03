using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderCrossbowTests
    {
        [Fact()]
        public void BuildTowerTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderCrossbow builder = new GameClient.GameObjects.Tower.TowerBuilderCrossbow();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Crossbow";
            Assert.Equal(expected, tower.Name);
        }
    }
}