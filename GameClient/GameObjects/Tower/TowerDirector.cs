namespace GameClient.GameObjects.Tower
{
    public class TowerDirector
    {
        public Tower Construct(ITowerBuilder builder)
        {
            builder.BuildTower();

            return builder.GetTower();
        }
    }
}
