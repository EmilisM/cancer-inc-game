using System.Linq;
using System.Threading.Tasks;
using GameServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Hubs
{
    public class GameInfoHub : Hub
    {
        private readonly GameInfo _gameInfo;

        public GameInfoHub(GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
        }

        public void RemoveClient()
        {
            var clientId = Context.ConnectionId;

            if (_gameInfo.ClientClasses.ContainsKey(clientId))
            {
                _gameInfo.ClientClasses.Remove(clientId);
            }
        }

        public async Task RegisterClient(string className)
        {
            var clientId = Context.ConnectionId;

            if (_gameInfo.ClientClasses.TryAdd(clientId, className))
            {
                await Clients.Caller.SendAsync("RegisterReceive", clientId, className, _gameInfo.Money,
                    _gameInfo.Health);
            }
        }

        public async Task NotifyClasses()
        {
            var classList = _gameInfo.ClientClasses.Select(key => key.Value);

            await Clients.Caller.SendAsync("ClassesReceive", classList);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}