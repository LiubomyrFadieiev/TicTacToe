using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Structs;

namespace TicTacToe.Interfaces
{
    interface ITacTacToeLogic
    {
        public bool AddPlayer(string name, char symbol);
        public Player GetCurrentPlayer();
        public bool ChangeCell(int row, int column);
        public bool CheckWin(char symbol, int row, int column);
    }
}
