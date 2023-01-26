using System;
namespace Lab1
{
	public class Bord
	{
		public int[][] gameBoard;
		private int leftIndex;
		private int rightIndex;
		private int playerPos;
		private int size;

		public Bord(int size)
		{
			this.size = size;

			for(int i = 0; Math.Sqrt(size) > i; i++)
			{
				gameBoard = new int[Convert.ToInt32(Math.Sqrt(size))][];
				gameBoard[i] = new int[Convert.ToInt32(Math.Sqrt(size))];
			}
			for(int i = 0; Math.Sqrt(size) > i; i++)
			{
				for(int j = 0; Math.Sqrt(size) > j; j++)
				{
					gameBoard[i][j] = (i*Convert.ToInt32(Math.Sqrt(size)))+(j+1);
				}
			}
		}
		public int getSize()
		{
			return this.size;
		}
	}
}

		