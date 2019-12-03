using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderRadarTests
    {
        [Fact()]
        public void BuildTowerTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderRadar builder = new GameClient.GameObjects.Tower.TowerBuilderRadar();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Radar";
            Assert.Equal(expected, tower.Name);
        }
    }
}