using GameClient.GameObjects.Class;

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
            _tower.ClassType = ClassType.Green;
            //TODO: Build the rest of object
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}