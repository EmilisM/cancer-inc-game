using GameClient.GameObjects.Class;
using System;
using System.Linq;
using GameClient.Api;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderCrossbow : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderCrossbow()
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