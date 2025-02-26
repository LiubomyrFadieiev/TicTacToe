using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Structs;

namespace TicTacToe.Classes
{
    public class TicTacToeLogic
    {
        // constants
        private const int boardSize = 3;
        private const int playerCount = 2;

        // number of turns taken
        private int numberOfTurns;

        // data properties
        public Cell[,] board { get; private set; }
        public List<Player> players { get; private set; }

        public TicTacToeLogic()
        {
            this.board = new Cell[boardSize, boardSize];
            this.players = new List<Player>();
            InitializeBoard();

        }

        // fill board with empty cells
        private void InitializeBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = new Cell { Value = ' ' };
                }
            }
        }

        // player logic
        public bool AddPlayer(string name, char symbol)
        {
            if (players.Count < playerCount)
            {
                players.Add(new Player { Name = name, Symbol = symbol });
                return true;
            }
            return false;
        }

        public Player GetCurrentPlayer()
        {
            return players[numberOfTurns % playerCount];
        }


        // change cell or return false if cell is already taken
        public bool ChangeCell(int row, int col)
        {
            if (board[row, col].Value == ' ')
            {
                board[row, col].Value = GetCurrentPlayer().Symbol;
                numberOfTurns++;
                return true;
            }
            return false;
        }

        // check winning conditions
        public bool CheckWin(char symbol, int row, int column)
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (board[row, i].Value != symbol)
                {
                    break;
                }
                if (i == boardSize - 1)
                {
                    return true;
                }
            }

            for (int i = 0; i < boardSize; i++)
            {
                if (board[i, column].Value != symbol)
                {
                    break;
                }
                if (i == boardSize - 1)
                {
                    return true;
                }
            }

            if (row == column)
            {
                for (int i = 0; i < boardSize; i++)
                {
                    if (board[i, column].Value != symbol)
                    {
                        break;
                    }
                    if (i == boardSize - 1)
                    {
                        return true;
                    }
                }
            }

            if (row + column == boardSize - 1)
            {
                for (int i = 0; i < boardSize; i++)
                {
                    if (board[i, boardSize - 1 - i].Value != symbol)
                    {
                        break;
                    }
                    if (i == boardSize - 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // return true if all cells are taken
        public bool IsBoardFull()
        {
            return numberOfTurns == boardSize * boardSize;
        }
    }
}
