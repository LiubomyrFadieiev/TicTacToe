using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Structs;

namespace TicTacToe.Interfaces
{
    public interface IView
    {
        public void PrintBoard(Cell[,] board);
        public Tuple<int, int> GetMove();
        public void ShowMessage(string message);
    }
}
