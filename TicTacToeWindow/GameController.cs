using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Structs;
using TicTacToe.Classes;

namespace TicTacToeWindow
{
    public class GameController
    {
        private TicTacToeLogic game;
        private MainWindow view;

        public GameController(MainWindow view)
        {
            this.view = view;
            game = new TicTacToeLogic();
            game.AddPlayer("Player X", 'X');
            game.AddPlayer("Player O", 'O');
        }

        public void HandleMove(int row, int col)
        {
            Player currentPlayer = game.GetCurrentPlayer();
            if (!game.ChangeCell(row, col)) return;

            if (game.CheckWin(currentPlayer.Symbol, row, col))
            {
                view.UpdateUI();
                view.ShowMessage($"{currentPlayer.Name} wins!");
                ResetGame();
                return;
            }

            if (game.IsBoardFull())
            {
                view.UpdateUI();
                view.ShowMessage("It's a draw!");
                ResetGame();
                return;
            }

            view.UpdateUI();
        }

        public void ResetGame()
        {
            game = new TicTacToeLogic();
            game.AddPlayer("Player X", 'X');
            game.AddPlayer("Player O", 'O');
            view.UpdateUI();
        }

        public Cell[,] GetBoard() => game.board;
        public Player GetCurrentPlayer() => game.GetCurrentPlayer();
    }
}
