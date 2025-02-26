using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;
using TicTacToe.Structs;

namespace TicTacToe.Classes
{
    class ConsoleView : IView
    {
        public void PrintBoard(Cell[,] board)
        {
            int boardSize = board.GetLength(0);
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize - 1; j++)
                {
                    Console.Write("{0,5}|", board[i, j].Value);
                }
                Console.Write("{0,5}|", board[i, boardSize - 1].Value);
                Console.WriteLine("\n{0}", new String('-', boardSize * 7));
            }
        }

        public Tuple<int, int> GetMove()
        {
            Console.Write("Enter your move (row, column): ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                return new Tuple<int, int>(-1, -1);
            }
            else
            {
                string[] array = input.Split(',');
                if (input.Length != 2)
                {
                    return new Tuple<int, int>(-1, -1);
                }
                return new Tuple<int, int>(int.Parse(array[0]) - 1, int.Parse(array[1]) - 1);
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
