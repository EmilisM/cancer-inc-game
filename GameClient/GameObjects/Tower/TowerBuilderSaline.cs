using System;

namespace GameClient.GameObjects.Tower
{
    public class SalineTowerBuilder : ITowerBuilder
    {
        private readonly Tower _tower;

        public SalineTowerBuilder()
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