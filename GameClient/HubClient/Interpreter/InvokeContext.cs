namespace GameClient.HubClient.Interpreter
{
    public class InvokeContext
    {
        public string TowerName { get; set; }
        public int TowerCost { get; set; }

        public string ClassType { get; set; }

        public string Action { get; set; }
    }
}
