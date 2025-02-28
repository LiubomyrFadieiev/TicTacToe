using System.Windows;
using System.Windows.Controls;
using TicTacToe.Classes;
using TicTacToe.Structs;
using TicTacToe.Interfaces;

namespace TicTacToeWindow
{
    public partial class MainWindow : Window, IView
    {
        private readonly IGameController controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new GameController(this);
            controller.AddPlayer("Player 1", 'X');
            controller.AddPlayer("Player 2", 'O');
            controller.ResetGame();
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            bool win = controller.HandleMove(row, col);
            if (win)
            {
                controller.ResetGame();
            }
            else
            {
                controller.UpdateGame();
            }
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            controller.ResetGame();
        }

        // PrintBoard
        public void UpdateUI(Cell[,] board)
        {

            Button[,] buttons = {
                { Cell00, Cell01, Cell02 },
                { Cell10, Cell11, Cell12 },
                { Cell20, Cell21, Cell22 }
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Content = board[i, j].Value.ToString();
                    buttons[i, j].IsEnabled = board[i, j].Value == ' ';
                }
            }
        }

        // ShowMessage
        public void ShowMessage(string message)
        {
            if (message.Contains("turn"))
            {
                TurnIndicator.Text = message;
                return;
            }
            MessageBox.Show(message, "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void IfAuto_Checked(object sender, RoutedEventArgs e)
        {
            controller.SetComputerPlayer(true);
        }

        private void IfAuto_Unchecked(object sender, RoutedEventArgs e)
        {
            controller.SetComputerPlayer(false);
        }

        public void PrintBoard(Cell[,] board)
        {
            UpdateUI(board);
        }

        public Tuple<int, int> GetMove()
        {
            throw new NotImplementedException();
        }
    }
}