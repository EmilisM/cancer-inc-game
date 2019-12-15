using System.Collections.Generic;
using System.Windows.Controls;
using GameClient.GameObjects.Class.Factory;

namespace GameClient.GameObjects.GameViewCanvas
{
    public class NullGameViewCanvasFacade : GameViewCanvasFacade
    {
        public override void AddClasses(List<string> exceptList)
        {
        }

        public override void AddTowers(IClass selectedClass)
        {
        }

        public override void AddClassSelectorMenu()
        {
        }

        public override void AddMainMenu()
        {
        }

        public override void PopulateGameGrid(List<List<string>> map, Grid grid)
        {
        }

        public override void AddGameGrid(List<List<string>> map)
        {
        }
    }
}