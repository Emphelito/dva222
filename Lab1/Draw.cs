using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Draw
    {
        public void printPuzzle(List<int> puzzle)
        {
            int i = Convert.ToInt32(Math.Sqrt(puzzle.Count()));
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < i; y++)
                {
                    if (puzzle[(i * x) + y] == 0)
                    {
                        Console.Write("X {0:G} X", puzzle[(i * x) + y]);
                    }
                    else
                    {
                        Console.Write(" {0:G} /", puzzle[(i * x) + y]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("///////////////");
            }
            Console.WriteLine("\n");
            
        }
    }
}
