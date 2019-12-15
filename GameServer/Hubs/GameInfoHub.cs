using System.Linq;
using System.Threading.Tasks;
using GameServer.GameInfoState;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Hubs
{
    public class GameInfoHub : Hub
    {
        private readonly Originator _originator;
        private readonly Caretaker _caretaker;

        public GameInfoHub(Originator originator, Caretaker caretaker)
        {
            _originator = originator;
            _caretaker = caretaker;

            if (_caretaker.Memento == null)
            {
                _caretaker.Memento = originator.CreateMemento();
            }
        }

        public void RemoveClient()
        {
            var clientId = Context.ConnectionId;

            if (_originator.State.ClientClasses.ContainsKey(clientId))
            {
                _originator.State.ClientClasses.Remove(clientId);
            }
        }

        public async Task RegisterClient(string className, int rows, int columns)
        {
            var clientId = Context.ConnectionId;

            if (_originator.State.MapGrid == null)
            {
                _originator.State.CreateMap(rows, columns);
            }

            if (_originator.State.ClientClasses.TryAdd(clientId, className))
            {
                await Clients.Caller.SendAsync("RegisterReceive", clientId, className, _originator.State.Money,
                    _originator.State.Health, _originator.State.MapGrid);
            }
        }

        public async Task NotifyClasses()
        {
            var classList = _originator.State.ClientClasses.Select(key => key.Value);

            await Clients.Caller.SendAsync("ClassesReceive", classList);
        }

        public async Task BuildTower(string tower, int cost, int row, int column)
        {
            if (_originator.State.Money < cost)
            {
                return;
            }

            _originator.State.MapGrid[row][column] = tower;
            _originator.State.Money -= cost;

            await Clients.All.SendAsync("BuildTowerReceive", _originator.State.MapGrid, _originator.State.Money);
        }

        public async Task ResetGame()
        {
            _originator.SetMemento(_caretaker.Memento);

            await Clients.All.SendAsync("ResetGameReceive");
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}