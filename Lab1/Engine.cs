using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Lab1
{
    public class Engine
    {
        List<int> puzzle = new List<int>();
        int emptyIndex;
        class init_puzzle
        {

            public List<int> nrGenerate(int size)
            {
                List<int> tmp = new List<int>();
                Random rand = new Random();


                for (int i = 0; i < size - 1; i++)
                {
                    int rand_nr = rand.Next(1, size * size);
                    tmp.Add(rand_nr);
                }
                tmp.Add(0);
                return tmp;
            }
        }
        public List<int> start_puzzle(int size)
        {
            init_puzzle obj= new init_puzzle();
            Draw obj2= new Draw();

            puzzle = obj.nrGenerate(size);
            emptyIndex = size - 1;
            obj2.printPuzzle(puzzle);

            return puzzle;
        }
        public void move(ConsoleKey loggedKey)
        {
            Moving obj = new Moving();
            Draw obj2 = new Draw();

            switch (loggedKey)
            {
                case ConsoleKey.LeftArrow:
                    puzzle = obj.moveLeft(puzzle, emptyIndex);
                    emptyIndex = emptyIndex - 1;
                    obj2.printPuzzle(puzzle);
                    break;

                case ConsoleKey.RightArrow:
                    puzzle = obj.moveRight(puzzle, emptyIndex);
                    emptyIndex = emptyIndex + 1;
                    obj2.printPuzzle(puzzle);
                    break;

                case ConsoleKey.UpArrow:
                    puzzle = obj.moveUp(puzzle,emptyIndex);
                    emptyIndex = emptyIndex - Convert.ToInt32(Math.Sqrt(puzzle.Count()));
                    obj2.printPuzzle(puzzle);
                    break;

                case ConsoleKey.DownArrow:
                    puzzle = obj.moveDown(puzzle, emptyIndex);
                    emptyIndex = emptyIndex + Convert.ToInt32(Math.Sqrt(puzzle.Count()));
                    obj2.printPuzzle(puzzle);
                    break;

                default: break;
            }
            List<int> puzzle_compare = new List<int>();
            puzzle_compare = puzzle;
            puzzle_compare.Sort();
            if (puzzle.SequenceEqual(puzzle_compare))
            {
                Console.WriteLine("Congrats!");
            }
            return;
        }
        
    }

}*/
