using GameClient.GameObjects.Class;
using System;
using System.Linq;
using GameClient.Api;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderLaser : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderLaser()
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