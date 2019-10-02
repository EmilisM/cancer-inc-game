using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Tower
{
    public class TowerDirectorRed
    {
        private ITowerBuilder _builder;
        public TowerBuildDirector(ITowerBuilder builder)
        {
            _builder = builder;
        }

        public void Build()
        {
            _builder.Damage = 2;
            _builder.Speed = 0.5;
        }

    }
}
