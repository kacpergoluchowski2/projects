using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.VievModels
{
    partial class TicTacToeVievModel : BindableObject
    {
		private string announcement;

		public string Announcement
		{
			get { return announcement; }
			set { announcement = value; OnPropertyChanged(); }
		}

		string mark = "X";
		string[,] board = new string[3, 3];
		private Command<Button> markCellCommand;
		public Command<Button> MarkCellCommand
		{
			get { return markCellCommand; }
			set { markCellCommand = value; }
		}

		public TicTacToeVievModel()
		{
			MarkCellCommand = new Command<Button>((button) =>
			{
                if (button.Text == null)
                {
					switchMark(button);
                }
            });
		}

		private void switchMark(Button button)
		{
			button.Text = mark;

            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            board[column, row] = mark;
            CheckWin();

            mark = mark == "X" ? mark = "O" : mark = "X";
        }

		private void CheckWin()
		{
			for (int i = 0; i < 3; i++) // pionowo
				if (board[i, 0] != null && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
					Announcement = "Wygrywa " + board[i, 0] + "!";
			for (int i = 0; i < 3; i++) // poziomo
				if (board[0, i] != null && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    Announcement = "Wygrywa " + board[i, 0] + "!";

            if (board[0, 0] != null && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                Announcement = "Wygrywa " + board[0, 0] + "!";
            if (board[0, 2] != null && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                Announcement = "Wygrywa " + board[0, 2] + "!";
        }
    }
}