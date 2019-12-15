using System.Windows;
using System.Windows.Controls;

namespace GameClient.Visitor
{
    public class VisitorAddChild : Visitor
    {
        public override void Visit(IElement element)
        {
            ((Grid) element.ParentNode).Children.Add((UIElement)element);
        }
    }
}
