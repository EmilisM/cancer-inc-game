using Xunit;
using GameClient.GameObjects.Tower;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower.Tests
{
    public class TowerBuilderSlingshotTests
    {
        [Fact()]
        public void BuildTowerTest()
        {
            GameClient.GameObjects.Tower.TowerBuilderSlingshot builder = new GameClient.GameObjects.Tower.TowerBuilderSlingshot();
            GameClient.GameObjects.Tower.TowerDirector director = new GameClient.GameObjects.Tower.TowerDirector();
            director.Construct(builder);
            GameClient.GameObjects.Tower.Tower tower = builder.GetTower();
            string expected = "Slingshot";
            Assert.Equal(expected, tower.Name);
        }
    }
}