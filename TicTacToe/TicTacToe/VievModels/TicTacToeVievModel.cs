using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.VievModels
{
    partial class TicTacToeVievModel : BindableObject
    {
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
            mark = mark == "X" ? mark = "O" : mark = "X";
        }
	}
}