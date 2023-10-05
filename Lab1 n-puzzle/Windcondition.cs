using System;
using System.Drawing;

namespace Lab1
{
	public class statusCondition
	{
		private bool status = false;
		private int[] tmpArray;
		public statusCondition(int size)
		{
			this.tmpArray = new int[size];

			for(int i = 0; size - 1 > i; i++) 
			{
				this.tmpArray[i] = i + 1;
			}
			tmpArray[size - 1] = 0;
		}
		public void statusCheck(Bord bord, int[] gameBord)
		{
			for(int i = 0; bord.getSize() > i; i++)
			{
				if (tmpArray[i] != gameBord[i]) {
					this.status = false;
					return;
				}

			}
			this.status = true;
			Console.WriteLine("Congrats you have won!!!!");
			Console.WriteLine();
		}
		public bool getStatus()
		{
			return status;
		}
	}
	
}

