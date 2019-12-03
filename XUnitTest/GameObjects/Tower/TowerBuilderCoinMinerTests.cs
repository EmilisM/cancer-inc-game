using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderCoinMinerTests
    {
        [Fact()]
        public void TowerBuilderCoinMinerTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderCoinMiner builder = new GameClient.GameObjects.Tower.TowerBuilderCoinMiner();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Coin miner";
            Assert.Equal(expected, tower.Name);
        }

    }
}