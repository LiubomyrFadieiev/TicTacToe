using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Classes;
using TicTacToe.Structs;

namespace TicTacToeWindow.GameControllers
{
    class GameControllerAuto : GameControllerManual, IGameController
    {
        char autoSymbol = 'O';
        public GameControllerAuto(MainWindow view) : base(view)
        {
            this.view = view;
            game = new TicTacToeLogic();
            game.AddPlayer("Player X", 'X');
            game.AddPlayer("Player O", 'O');
        }

        override public void HandleMove(int row, int col)
        {
            Player currentPlayer = game.GetCurrentPlayer();
            if (!game.ChangeCell(row, col)) return;

            if (CheckEnd(currentPlayer, row, col)) return;

            view.UpdateUI();

            HandleAutoMove();
        }

        private void HandleAutoMove()
        {
            Player currentPlayer = game.GetCurrentPlayer();
            Tuple<int,int> pos = game.AutoChangeCell();

            if (CheckEnd(currentPlayer, pos.Item1, pos.Item2)) return;

            view.UpdateUI();

        }

        private bool CheckEnd(Player currentPlayer, int row, int col)
        {
            bool end = false;
            if (game.CheckWin(currentPlayer.Symbol, row, col))
            {
                view.UpdateUI();
                view.ShowMessage($"{currentPlayer.Name} wins!");
                ResetGame();
                end = true;
            }
            if (game.IsBoardFull())
            {
                view.UpdateUI();
                view.ShowMessage("It's a draw!");
                ResetGame();
                end = true;
            }
            return end;
        }
    }
}
