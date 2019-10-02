using System;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderRadar : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderRadar()
        {
            _tower = new Tower();
        }

        public void BuildTower()
        {
            throw new NotImplementedException();
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}