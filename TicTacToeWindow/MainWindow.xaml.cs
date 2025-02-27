using System.Windows;
using System.Windows.Controls;
using TicTacToe.Classes;
using TicTacToeWindow.GameControllers;

namespace TicTacToeWindow
{
    public partial class MainWindow : Window
    {
        private GameController controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new TicTacToeWindow.GameController(this);
            UpdateUI();
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            controller.HandleMove(row, col);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            controller.ResetGame();
        }

        public void UpdateUI()
        {
            var board = controller.GetBoard();
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

            TurnIndicator.Text = $"{controller.GetCurrentPlayer().Name}'s turn";
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}