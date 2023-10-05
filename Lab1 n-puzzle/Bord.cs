using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab1
{
	public class Bord
	{

		//Fields

		private int[] gameBord; 
		private int bordSqrt;
		private int[] leftIndex;
		private int[] rightIndex;
		private int size;

		//Constructor
		public Bord(int size)
		{
			this.size = size;
			this.bordSqrt = Convert.ToInt32(Math.Sqrt(size));


            this.gameBord = new int[size];

			this.leftIndex = new int[Convert.ToInt32(Math.Sqrt(size))];
            this.rightIndex = new int[Convert.ToInt32(Math.Sqrt(size))];

			this.gameBord[0] = 0;
			for(int i = 1; size > i; i++)
			{
				this.gameBord[i] = i;
			}
            for (int i = 0; Math.Sqrt(size) > i; i++)
			{
				leftIndex[i] = Convert.ToInt32(Math.Sqrt(size)) * i;
				rightIndex[i] = Convert.ToInt32(Math.Sqrt(size))* i + Convert.ToInt32(Math.Sqrt(size)) - 1;
            }
		}
		//Shuffle
		public int[] shuffle(Moving move) 
		{
            Random rand = new Random();

			for(int i = 0; i < size; i++)
			{
				int dir = rand.Next(0,4);

				switch(dir)
				{
					case 0:
						move.moveUp(this);
						break;
					case 1:
						move.moveLeft(this);
						break;
					case 2:
						move.moveRight(this);
						break;
					case 3:
						move.moveDown(this);
                        break;	
				}
			}
			for(int i = 0; i < size; i++)
			{
				move.moveDown(this);
				move.moveRight(this);
			}

			return this.gameBord;

        }

		//Get functions
		public int[] getRightIndex()
		{
			return this.rightIndex;
		}
        public int[] getLeftIndex()
        {
            return this.leftIndex;
        }
        public int getSize()
		{
			return this.size;
		}
        public int getSqrt()
        {
            return this.bordSqrt;
        }
        public int[] returnBord()
        {
            return this.gameBord;
        }
    }
}

		