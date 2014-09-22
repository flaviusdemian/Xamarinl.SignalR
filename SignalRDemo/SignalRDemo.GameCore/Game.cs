using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.GameCore
{
    public class Game
    {
        public Game()
        {
            Board = new Board();
            PlayerTurn = true;
            IsGameFinished = false;
            IsGameStarted = false;
        }

        public Board Board { get; set; }

        public bool PlayerTurn { get; set; } // X = true / 0 = false

        public bool IsGameFinished { get; set; }

        public bool IsGameStarted { get; set; }

        public bool AddMoveForPlayer(int position, bool player, out bool gameIsOver, out bool? winner)
        {
            // 1. game is not finished
            // 2. is player's turn
            // 3. the move has not yet been made
            if(!IsGameFinished && PlayerTurn == player && Board.BoardData[position].HasValue == false)
            {
                Board.BoardData[position] = player;
                PlayerTurn = !player;

                bool tempWinner;
                // did the move make someone a winner?
                if (Board.DidSomeoneWinAndWho(out tempWinner))
                {
                    winner = tempWinner;
                    gameIsOver = true;
                    IsGameFinished = true;
                }
                // or end the game in a tie?
                else if (Board.IsTie())
                {
                    winner = null;
                    gameIsOver = true;
                    IsGameFinished = true;
                }
                else
                {
                    gameIsOver = false;
                    winner = null;
                }

                return true;
            }
            winner = null;
            gameIsOver = false;

            return false;
        }
    }
}
