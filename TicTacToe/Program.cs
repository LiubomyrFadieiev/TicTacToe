using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using TicTacToe.Structs;
using TicTacToe.Classes;
using TicTacToe.Interfaces;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeLogic game = new TicTacToeLogic();
            IView view = new ConsoleView();
            GameController controller = new GameController(game, view);
            controller.AddPlayer("Player 1", 'X');
            controller.AddPlayer("Player 2", 'O');
            controller.PlayGame();
        }
    }

}

