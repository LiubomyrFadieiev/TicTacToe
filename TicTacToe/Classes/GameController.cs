using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;
using TicTacToe.Structs;

namespace TicTacToe.Classes
{
    public class GameController : IGameController
    {
        // model and view
        private readonly TicTacToeLogic game;
        private readonly IView view;

        // use computer for second player
        protected bool useComputer = false;

        public GameController()
        {
            game = new TicTacToeLogic();
            view = new ConsoleView();
        }

        public GameController(IView view)
        {
            game = new TicTacToeLogic();
            this.view = view;
        }

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
                PrintWindow(string.Format("{0}'s turn", currentPlayer.Name));

                Tuple<int, int> move = view.GetMove();
                Win = HandleMove(move.Item1, move.Item2, currentPlayer);

            }
        }

        public bool HandleMove(int row, int col, Player? player = null)
        {
            bool result = false;
            Player currentPlayer = player ?? game.GetCurrentPlayer();
            if (!CheckValidity(row, col) || !game.ChangeCell(row, col))
            {
                view.ShowMessage("Invalid move! Try again.");
                return result;
            }

            result = CheckWinningConditions(row, col, currentPlayer);

            if (useComputer)
            {
                Tuple<int,int> pos = game.AutoChangeCell();
                result = CheckWinningConditions(pos.Item1, pos.Item2, game.GetCurrentPlayer());
            }
            return result;
        }

        private bool CheckValidity(int row, int col)
        {
            return row >= 0 && row < game.Board.GetLength(0) && col >= 0 && col < game.Board.GetLength(1);
        }

        private bool CheckWinningConditions(int row, int col, Player currentPlayer) 
        {
            if (game.CheckWin(currentPlayer.Symbol, row, col))
            {
                PrintWindow(string.Format("{0} wins!", currentPlayer.Name));
                return true;
            }
            else if (game.IsBoardFull())
            {
                PrintWindow("It's a draw!");
                return true;
            }
            return false;
        }

        private void PrintWindow(string message)
        {
            view.PrintBoard(game.Board);
            view.ShowMessage(message);
        }

        public void SetComputerPlayer(bool useComputer)
        {
            this.useComputer = useComputer;
        }

        public void ResetGame()
        {
            game.ResetGame();
            UpdateGame();
        }

        public void UpdateGame()
        {
            PrintWindow(string.Format("{0}'s turn", game.GetCurrentPlayer().Name));
        }
    }

}
