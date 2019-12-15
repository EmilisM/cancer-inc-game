using System.Collections.Generic;

namespace GameClient.Visitor
{
    public class ObjectStructure
    {
        private List<IElement> _element = new List<IElement>();

        public void Attach(IElement element)
        {
            _element.Add(element);
        }

        public void Detach(IElement element)
        {
            _element.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (var element in _element)
            {
                element.Accept(visitor);
            }
        }
    }
}