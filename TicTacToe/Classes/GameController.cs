using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;
using TicTacToe.Structs;

namespace TicTacToe.Classes
{
    public class GameController
    {
        // model and view
        private TicTacToeLogic game;
        private IView view;

        public GameController(TicTacToeLogic game, IView view)
        {
            this.game = game;
            this.view = view;
        }

        public void AddPlayer(string name, char symbol)
        {
            if (!game.AddPlayer(name, symbol))
            {
                view.ShowMessage("Game is full.");
            }
        }

        // main game loop
        public void PlayGame()
        {
            bool Win = false;

            while (!Win)
            {
                Player currentPlayer = game.GetCurrentPlayer();
                view.PrintBoard(game.Board);
                view.ShowMessage(string.Format("{0}'s turn", currentPlayer.Name));

                Tuple<int, int> move = view.GetMove();
                if (move.Item1 < 0 || move.Item1 >= game.Board.GetLength(0) || move.Item2 < 0 || move.Item2 >= game.Board.GetLength(1))
                {
                    view.ShowMessage("Invalid move! Try again.\nPress ENTER to continue.");
                    Console.ReadLine();
                    continue;
                }
                if (!game.ChangeCell(move.Item1, move.Item2))
                {
                    view.ShowMessage("Invalid move! Try again.\nPress ENTER to continue.");
                    Console.ReadLine();
                    continue;
                }

                if (game.CheckWin(currentPlayer.Symbol, move.Item1, move.Item2))
                {
                    view.PrintBoard(game.Board);
                    view.ShowMessage(string.Format("{0} wins!\nPress ENTER to continue.", currentPlayer.Name));
                    Win = true;
                }
                else if (game.IsBoardFull())
                {
                    view.PrintBoard(game.Board);
                    view.ShowMessage("It's a draw!\nPress ENTER to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
