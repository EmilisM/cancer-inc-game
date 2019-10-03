using GameClient.GameObjects.Class;
using System;
using System.Linq;
using GameClient.Api;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderSaline : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderSaline()
        {
            _tower = new Tower();
        }

        public void BuildTower()
        {
            _tower.ClassType = ClassType.Red;
            _tower.Name = "Saline";
            var result = ApiClient.GetTowers(_tower.Name).FirstOrDefault();

            _tower.Cost = result.Cost;
            //_tower.T
            _tower.Damage = result.Damage;
            _tower.Speed = result.Speed;
            _tower.Size = result.Size;
            _tower.Range = result.Range;
            _tower.Effect = result.Effect;


            //TODO: Build the rest of object
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}