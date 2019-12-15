namespace GameClient.HubClient.Chain
{
    public class ClientIdHandler : Handler
    {
        public override void HandleRequest(string request, ClientItemType type)
        {
            if (type == ClientItemType.ClientId)
            {
                MainWindow.ClassId = request;
            }
            else
            {
                TypeHandler.HandleRequest(request, type);
            }
        }
    }
}
