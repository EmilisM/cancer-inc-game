namespace GameClient.GameObjects.Tower
{
    public class TowerBuildDirectorGreen
    {
        private ITowerBuilder _builder;
        public TowerBuildDirectorGreen(ITowerBuilder builder)
        {
            _builder = builder;
        }

        public void Build()
        {
            _builder.Damage = 1;
            _builder.Speed = 1;
        }

    }
}
