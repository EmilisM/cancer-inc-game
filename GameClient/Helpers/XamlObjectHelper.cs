using System.IO;
using System.Windows.Markup;
using System.Xml;
using GameClient.GameObjects.MainMenuButton;

namespace GameClient.Helpers
{
    public static class XamlObjectHelper
    {
        public static T DeepClone<T>(T source) where T : class
        {
            var xamlWriter = XamlWriter.Save(source);

            var stringReader = new StringReader(xamlWriter);
            var xmlReader = XmlReader.Create(stringReader);
            var newObject = (PlayMainMenuButton) XamlReader.Load(xmlReader);

            return newObject as T;
        }
    }
}