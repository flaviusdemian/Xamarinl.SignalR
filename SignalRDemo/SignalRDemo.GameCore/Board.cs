using System.Linq;

namespace SignalRDemo.GameCore
{
    public class Board
    {
        // X = true ; 0 = false

        public Board()
        {
            BoardData = new bool?[9];
        }

        public bool?[] BoardData { get; set; }

        public bool DidSomeoneWinAndWho(out bool winner)
        {
            winner = false;
            if (CheckPlayerWin(true))
            {
                winner = true;
                return true;
            }
            if (CheckPlayerWin(false))
            {
                return true;
            }
            return false;
        }

        public bool IsTie()
        {
            foreach (var position in BoardData)
            {
                if (position.HasValue == false) return false;
            }
            return true;
        }

        private bool CheckPlayerWin(bool player)
        {
            return BoardData != null && BoardData.Count() == 9 &&
                   (BoardData[0] == BoardData[1] && BoardData[1] == BoardData[2] && BoardData[2] == player) || // Row 1
                   (BoardData[3] == BoardData[4] && BoardData[4] == BoardData[5] && BoardData[5] == player) || // Row 2
                   (BoardData[6] == BoardData[7] && BoardData[7] == BoardData[8] && BoardData[8] == player) || // Row 3
                   (BoardData[0] == BoardData[3] && BoardData[3] == BoardData[6] && BoardData[6] == player) ||
                   // Column 1
                   (BoardData[1] == BoardData[4] && BoardData[4] == BoardData[7] && BoardData[7] == player) ||
                   // Column 2
                   (BoardData[2] == BoardData[5] && BoardData[5] == BoardData[8] && BoardData[8] == player) ||
                   // Column 3
                   (BoardData[0] == BoardData[4] && BoardData[4] == BoardData[8] && BoardData[8] == player) || // Diag 1
                   (BoardData[6] == BoardData[4] && BoardData[4] == BoardData[2] && BoardData[2] == player); // Diag 2
        }
    }
}