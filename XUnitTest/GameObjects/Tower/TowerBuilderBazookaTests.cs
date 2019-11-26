﻿using Xunit;
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
            string expected = "Bazooka";
            Assert.Equal(expected, tower.Name);
        }
    }
}