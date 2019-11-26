using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderBazookaTests
    {
        [Fact()]
        public void TowerBuilderBazookaTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderBazooka builder = new GameClient.GameObjects.Tower.TowerBuilderBazooka();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string name = "Bazooka";
            Assert.Equal(tower.Name, name);
        }

        [Fact()]
        public void BuildTowerTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetTowerTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}