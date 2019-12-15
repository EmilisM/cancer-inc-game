namespace GameClient.HubClient.Chain
{
    public class HealthHandler : Handler
    {
        public override void HandleRequest(string request, ClientItemType type)
        {
            if (type == ClientItemType.Health)
            {
                MainWindow.HealthLabel.Content = request;
            }
            else
            {
                _typeHandler.HandleRequest(request, type);
            }
        }
    }
}