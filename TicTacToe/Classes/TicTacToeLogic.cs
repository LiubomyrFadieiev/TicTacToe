using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;
using TicTacToe.Structs;

namespace TicTacToe.Classes
{
    public class TicTacToeLogic : ITacTacToeLogic
    {
        // constants
        private const int boardSize = 3;
        private const int playerCount = 2;

        // number of turns taken
        private int numberOfTurns;

        // data properties
        public Cell[,] Board { get; private set; }
        public List<Player> Players { get; private set; }

        public TicTacToeLogic()
        {
            this.Board = new Cell[boardSize, boardSize];
            this.Players = [];
            InitializeBoard();

        }

        // fill board with empty cells
        private void InitializeBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Board[i, j] = new Cell { Value = ' ' };
                }
            }
        }

        // player logic
        public bool AddPlayer(string name, char symbol)
        {
            if (Players.Count < playerCount)
            {
                Players.Add(new Player { Name = name, Symbol = symbol });
                return true;
            }
            return false;
        }

        public Player GetCurrentPlayer()
        {
            return Players[numberOfTurns % playerCount];
        }


        // change cell or return false if cell is already taken
        public bool ChangeCell(int row, int col)
        {
            if (Board[row, col].Value == ' ')
            {
                Board[row, col].Value = GetCurrentPlayer().Symbol;
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
                if (Board[row, i].Value != symbol)
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
                if (Board[i, column].Value != symbol)
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
                    if (Board[i, column].Value != symbol)
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
                    if (Board[i, boardSize - 1 - i].Value != symbol)
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

        // logic for auto move
        public Tuple<int,int> AutoChangeCell()
        {
            Random random = new();
            int row = random.Next(0, boardSize);
            int col = random.Next(0, boardSize);
            while (Board[row, col].Value != ' ')
            {
                row = random.Next(0, boardSize);
                col = random.Next(0, boardSize);
            }
            Board[row, col].Value = GetCurrentPlayer().Symbol;
            numberOfTurns++;
            return new Tuple<int,int>(row, col);
        }
    }
}
