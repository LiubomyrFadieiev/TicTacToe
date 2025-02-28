using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Structs;

namespace TicTacToe.Interfaces
{
    public interface IGameController
    {
        public void AddPlayer(string name, char symbol);
        public void PlayGame();
        public void ResetGame();
        public void UpdateGame();
        public bool HandleMove(int row, int col, Player? player = null);
        public void SetComputerPlayer(bool useComputer);
    }
}
