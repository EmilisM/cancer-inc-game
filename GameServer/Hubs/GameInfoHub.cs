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

        public async Task RegisterClient(string className, int rows, int columns)
        {
            var clientId = Context.ConnectionId;

            if (_gameInfo.MapGrid == null)
            {
                _gameInfo.CreateMap(rows, columns);
            }

            if (_gameInfo.ClientClasses.TryAdd(clientId, className))
            {
                await Clients.Caller.SendAsync("RegisterReceive", clientId, className, _gameInfo.Money,
                    _gameInfo.Health, _gameInfo.MapGrid);
            }
        }

        public async Task NotifyClasses()
        {
            var classList = _gameInfo.ClientClasses.Select(key => key.Value);

            await Clients.Caller.SendAsync("ClassesReceive", classList);
        }

        public async Task BuildTower(string tower, int cost, int row, int column)
        {
            if (_gameInfo.Money < cost)
            {
                return;
            }

            _gameInfo.MapGrid[row][column] = tower;
            _gameInfo.Money -= cost;

            await Clients.All.SendAsync("BuildTowerReceive", _gameInfo.MapGrid, _gameInfo.Money);
        }

        public async Task GameMap(string elementName, int index)
        {
            await Clients.All.SendAsync("NotifyMap", _gameInfo.MapGrid);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}