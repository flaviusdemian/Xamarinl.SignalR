using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRDemo.GameCore;

namespace SignalRDemo.Web.Hubs
{
    public class GameHub : Hub
    {
        private static List<GameSession> gameSessions = new List<GameSession>();

        public void ConnectToOpponent(string opponentId, string currentPlayerId)
        {
            var session = GetGameSessionForConnectingPlayerAndStartGameIfReady(currentPlayerId, Context.ConnectionId);
            if(session != null)
            {
                if(!session.Game.IsGameStarted && string.IsNullOrEmpty(session.OPlayerConnectionId) && string.IsNullOrEmpty(session.OPlayerId))
                {
                    session.OPlayerId = opponentId;
                }
            }
        }

        public void AddMove(int position)
        {
            var session = gameSessions.FirstOrDefault(x => x.OPlayerConnectionId == Context.ConnectionId || x.XPlayerConnectionId == Context.ConnectionId);
            if (session != null && position >= 0 && position <= 8 && session.Game.IsGameStarted)
            {
                var currentPlayerIsX = session.XPlayerConnectionId == Context.ConnectionId;
                bool gameOver;
                bool? winner;
                var opponentConnectionId = currentPlayerIsX ? session.OPlayerConnectionId : session.XPlayerConnectionId;

                if(session.Game.AddMoveForPlayer(position, currentPlayerIsX, out gameOver, out winner))
                {
                    // update interfaces
                    Clients.Caller.moveAccepted(position, currentPlayerIsX);
                    Clients.Client(opponentConnectionId).moveAccepted(position, currentPlayerIsX);

                    if(gameOver)
                    {
                        var winnerName = string.Empty;
                        if (winner.HasValue && winner.Value)
                        {
                            winnerName = session.XPlayerId;
                        }
                        else if(winner.HasValue)
                        {
                            winnerName = session.OPlayerId;
                        }
                        Clients.Clients(new List<string>() { session.OPlayerConnectionId, session.XPlayerConnectionId }).gameOver(winnerName);

                        gameSessions.Remove(session);
                    }
                }
            }
        }

        private GameSession GetGameSessionForConnectingPlayerAndStartGameIfReady(string playerId, string playerConnectionId)
        {
            var tmp = gameSessions.FirstOrDefault(x => (x.XPlayerId == playerId) 
                || (x.OPlayerId == playerId));
            
            if(tmp != null)
            {
                // O already connected
                if(tmp.XPlayerId == playerId && !string.IsNullOrEmpty(tmp.OPlayerConnectionId) && !string.IsNullOrEmpty(tmp.OPlayerId)
                    && string.IsNullOrEmpty(tmp.XPlayerConnectionId))
                {
                    tmp.XPlayerConnectionId = playerConnectionId;
                    Clients.Clients(new List<string>() { tmp.OPlayerConnectionId, tmp.XPlayerConnectionId }).startGame(tmp.XPlayerId);
                    tmp.Game.IsGameStarted = true;
                    return tmp;
                }
                // X already is connected
                else if(tmp.OPlayerId == playerId && !string.IsNullOrEmpty(tmp.XPlayerConnectionId) && !string.IsNullOrEmpty(tmp.XPlayerId)
                    && string.IsNullOrEmpty(tmp.OPlayerConnectionId))
                {
                    tmp.OPlayerConnectionId = playerConnectionId;
                    Clients.Clients(new List<string>() { tmp.OPlayerConnectionId, tmp.XPlayerConnectionId }).startGame(tmp.XPlayerId);
                    tmp.Game.IsGameStarted = true;
                    return tmp;
                }
                // player is already connected to a game
                else 
                {
                    return null;
                }
            }
            else
            {
                tmp = new GameSession()
                {
                    XPlayerConnectionId = playerConnectionId,
                    XPlayerId = playerId
                };
                gameSessions.Add(tmp);

                return tmp;
            }
        }
    }

    public class GameSession
    {
        public string XPlayerId { get; set; }
        public string OPlayerId { get; set; }
        public string XPlayerConnectionId { get; set; }
        public string OPlayerConnectionId { get; set; }
        public Game Game { get; set; }

        public GameSession()
        {
            XPlayerId = XPlayerConnectionId = OPlayerId = OPlayerConnectionId = string.Empty;
            Game = new Game();
        }
    }
}