namespace GameClient.HubClient.Chain
{
    class MoneyHandler : Handler
    {
        public override void HandleRequest(string request, ClientItemType type)
        {
            if (type == ClientItemType.Money)
            {
                MainWindow.MoneyLabel.Content = request;
            }
            else
            {
                TypeHandler.HandleRequest(request, type);
            }
        }
    }
}
