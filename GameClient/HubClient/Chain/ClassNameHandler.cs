namespace GameClient.HubClient.Chain
{
    public class ClassNameHandler : Handler
    {
        public override void HandleRequest(string request, ClientItemType type)
        {
            if (type == ClientItemType.ClassName)
            {
                MainWindow.ClassLabel.Content = request;
            }
            else
            {
                _typeHandler.HandleRequest(request, type);
            }
        }
    }
}
