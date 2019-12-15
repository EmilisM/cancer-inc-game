using System.Collections.Generic;
using System.Windows.Controls;

namespace GameClient.Visitor
{
    public abstract class Visitor
    {
        public abstract void VisitMap(List<List<Label>> map);
    }
}