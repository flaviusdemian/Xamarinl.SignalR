using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo.Web
{
    [HubName("Lounge")]
    public class LoungeHub : Hub
    {
        private static List<PlayerRoom> roomsAndPlayers = new List<PlayerRoom>();

        public void PingHello(string param)
        {
            Clients.All.pongHello("You wrote: " + param);
        }

        public void ConnectToRoom(string room, string playerName)
        {
            //cleanup before connecting to new room
            RemovePlayerFromAllGroups(playerName);

            // connect to new room
            Groups.Add(this.Context.ConnectionId, room);
            roomsAndPlayers.Add(new PlayerRoom() { PlayerConnectionId = Context.ConnectionId, Room = room, PlayerName = playerName });
            Clients.Group(room).addPlayerToCurrentRoom(playerName);
            Clients.Caller.getPlayersForCurrentRoom(GetPlayersForRoom(room));
        }

        public void StartNewGame(string opponentName, string currentPlayerName)
        {
            var opponent = roomsAndPlayers.FirstOrDefault(x => x.PlayerName == opponentName);
            if (opponent != null)
            {
                Clients.Client(opponent.PlayerConnectionId).goToGame(currentPlayerName);
                Clients.Caller.goToGame(opponentName);
                RemovePlayerFromAllGroups(opponentName);
                RemovePlayerFromAllGroups(currentPlayerName);
            }
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool result)
        {
            var tmp = roomsAndPlayers.FirstOrDefault(x => x.PlayerConnectionId == Context.ConnectionId);
            if (tmp != null)
            {
                RemovePlayerFromAllGroups(tmp.PlayerName);
            }

            return base.OnDisconnected(result);
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            return base.OnReconnected();
        }

        private string[] GetPlayersForRoom(string room)
        {
            return roomsAndPlayers.Where(x => x.Room == room).Select(x => x.PlayerName).ToArray();
        }

        private void RemovePlayerFromAllGroups(string playerName)
        {
            var previousGroups = roomsAndPlayers.Where(x => x.PlayerName == playerName).ToList();
            if (previousGroups != null)
            {
                var rooms = previousGroups.Select(x => x.Room).ToList();
                Clients.Groups(rooms).removePlayerFromCurrentRoom(playerName);
                foreach (var previousGroup in previousGroups)
                {
                    roomsAndPlayers.Remove(previousGroup);
                    Groups.Remove(Context.ConnectionId, previousGroup.Room);
                }
            }
        }
    }

    public class PlayerRoom
    {
        public string PlayerConnectionId { get; set; }
        public string PlayerName { get; set; }
        public string Room { get; set; }
    }
}