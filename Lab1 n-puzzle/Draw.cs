using System.Drawing;

namespace Lab1
{
    public class Draw
    {
        private System.ConsoleColor bColor;
        private List<tile> tiles = new List<tile>();
        public Draw(int size, int[] gameBord) 
        {
            for(int i = 0; i < size; i++)
            {
                tiles.Add(new tile());
            }
        }
        public void printPuzzle(Bord bord, int[] gameBord)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; bord.getSqrt() > i; i++)
            {
                for (int j = 0; bord.getSqrt() > j; j++)
                {
                    Console.BackgroundColor = bColor;
                    Console.Write(" ");
                    tiles[i * bord.getSqrt() + j].print(gameBord[i * bord.getSqrt() + j]);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private class tile
        {
            private System.ConsoleColor cColor;
            public tile()
            {
                Random random = new Random();
                cColor = (ConsoleColor)random.Next(16);
                while (cColor == ConsoleColor.Black) //To make sure background color is not black since foreground is black
                {
                    cColor = (ConsoleColor)random.Next(16);
                }
            }
            public void print(int nr)
            {
                Console.BackgroundColor = cColor;
                Console.Write(" " + nr);
            }
        }
    }

    
}

/*
         public Draw() 
        {
            Random random = new Random();
            bColor = (ConsoleColor)random.Next(16);
            while (bColor == ConsoleColor.Black)
            {
                bColor = (ConsoleColor)random.Next(16);
            }
        }
        public void printPuzzle(Bord bord, int[] gameBord)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; bord.getSqrt() > i; i++)
            {
                for (int j = 0; bord.getSqrt() > j; j++)
                {
                    Console.BackgroundColor = bColor;
                    Console.Write( " " + gameBord[i * bord.getSqrt() + j] + " " );
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    } */