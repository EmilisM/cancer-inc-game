using System.Collections.Generic;
using System.Windows.Controls;
using GameClient.GameObjects.Class.Factory;

namespace GameClient.GameObjects.GameViewCanvas
{
    public abstract class GameViewCanvasFacade : IGameViewCanvasFacade
    {
        public static readonly IGameViewCanvasFacade Null = new NullGameViewCanvasFacade();

        public abstract void AddClasses(List<string> exceptList);

        public abstract void AddTowers(IClass selectedClass);

        public abstract void AddClassSelectorMenu();

        public abstract void AddMainMenu();

        public abstract void PopulateGameGrid(List<List<string>> map, Grid grid);

        public abstract void AddGameGrid(List<List<string>> map);
    }
}