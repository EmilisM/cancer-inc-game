namespace GameClient.HubClient.Chain
{
    public abstract class Handler
    {
        protected Handler _typeHandler;

        public void SetNextType(Handler nextType)
        {
            _typeHandler = nextType;
        }

        public abstract void HandleRequest(string request, ClientItemType type);
    }
}
