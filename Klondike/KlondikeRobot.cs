using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp.Klondike
{
	public class KlondikeRobot
	{
		public void SearchPartten1(string board)
		{
			Search(board.Split('|'));
		}

		public void SearchPartten2(string board)
		{
			Search(board.Split(' '));
		}

    public int[] Convert(string[] board)
    {
      var boardInt = new int[board.Length];
      for (int i = 0; i < board.Length; i++)
      {
        boardInt[i] = int.Parse(board[i]);
      }
      return boardInt;
    }

		public void Search(string[] board)
		{
			Search(Convert(board));
		}

		public void Search(int[] board)
		{

		}
	}


}
