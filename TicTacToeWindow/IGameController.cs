using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Structs;

namespace TicTacToeWindow
{
    interface IGameController
    {
        public void HandleMove(int row, int col);
        public void ResetGame();
        public Cell[,] GetBoard();
        public Player GetCurrentPlayer();
    }
}
