using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderLaserTests
    {
        [Fact()]
        public void TowerBuilderLaserTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderLaser builder = new GameClient.GameObjects.Tower.TowerBuilderLaser();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Laser";
            Assert.Equal(expected, tower.Name);
        }
    }
}