using System.Windows;
using System.Windows.Controls;

namespace GameClient.Visitor
{
    public class VisitorRowProperty : Visitor
    {
        public override void Visit(IElement element)
        {
            ((UIElement) element).SetValue(Grid.RowProperty, element.RowPropertyValue);
        }
    }
}