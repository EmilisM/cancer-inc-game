using GameClient.GameObjects.Class;

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
            _tower.ClassType = ClassType.Red;
            //TODO: Build the rest of object
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}