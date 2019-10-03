using GameClient.GameObjects.Class;
using System;
using System.Linq;
using GameClient.Api;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderCoinMiner : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderCoinMiner()
        {
            _tower = new Tower();
        }

        public void BuildTower()
        {
            //TODO: Build the rest of object
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}