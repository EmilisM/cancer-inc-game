using System.Windows;

namespace GameClient.Visitor
{
    public interface IElement
    {
        void Accept(Visitor visitor);

        public int RowPropertyValue { get; set; }

        public UIElement ParentNode { get; set; }
    }
}