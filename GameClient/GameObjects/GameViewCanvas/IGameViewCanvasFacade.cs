using System.Collections.Generic;
using System.Windows.Controls;
using GameClient.GameObjects.Class.Factory;

namespace GameClient.GameObjects.GameViewCanvas
{
    public interface IGameViewCanvasFacade
    {
        void AddClasses(List<string> exceptList);
        void AddTowers(IClass selectedClass);
        void AddClassSelectorMenu();
        void AddMainMenu();
        void PopulateGameGrid(List<List<string>> map, Grid grid);
        void AddGameGrid(List<List<string>> map);
    }
}