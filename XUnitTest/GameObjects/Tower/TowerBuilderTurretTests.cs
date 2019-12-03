using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderTurretTests
    {
        [Fact()]
        public void BuildTowerTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderTurret builder = new GameClient.GameObjects.Tower.TowerBuilderTurret();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Turret";
            Assert.Equal(expected, tower.Name);
        }
    }
}