namespace GameClient.HubClient.Chain
{
    public abstract class Handler
    {
        protected Handler TypeHandler;

        public void SetNextType(Handler nextType)
        {
            TypeHandler = nextType;
        }

        public abstract void HandleRequest(string request, ClientItemType type);
    }
}
