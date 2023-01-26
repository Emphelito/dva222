using System;
namespace Lab1
{
    public class Moving
    {
        private bool legalMove (int move, Bord bord)
        {
            return false;
        }

        public List<int> moveUp(List<int> puzzle, int emptyIndex)
        {
            //if (!legalMove(0, puzzle)) return;

            puzzle.RemoveAt(emptyIndex);
            puzzle.Insert(emptyIndex, puzzle[emptyIndex - Convert.ToInt32(Math.Sqrt(puzzle.Count()))]);
            puzzle.RemoveAt(emptyIndex - Convert.ToInt32(Math.Sqrt(puzzle.Count())));
            puzzle.Insert(emptyIndex - Convert.ToInt32(Math.Sqrt(puzzle.Count())), 0);
            return puzzle;
        }
        public List<int> moveDown(List<int> puzzle, int emptyIndex)
        {
            puzzle.RemoveAt(emptyIndex);
            puzzle.Insert(emptyIndex, puzzle[(emptyIndex - 1) + Convert.ToInt32(Math.Sqrt(puzzle.Count()))]);
            puzzle.RemoveAt(emptyIndex + Convert.ToInt32(Math.Sqrt(puzzle.Count())));
            puzzle.Insert(emptyIndex + Convert.ToInt32(Math.Sqrt(puzzle.Count())), 0);
            return puzzle;
        }
        public List<int> moveRight(List<int> puzzle, int emptyIndex)
        {
            puzzle.RemoveAt(emptyIndex);
            puzzle.Insert(emptyIndex, puzzle[emptyIndex]);
            puzzle.RemoveAt(emptyIndex + 1);
            puzzle.Insert(emptyIndex + 1, 0);
            return puzzle;
        }
        public List<int> moveLeft(List<int> puzzle, int emptyIndex)
        {
            puzzle.RemoveAt(emptyIndex);
            puzzle.Insert(emptyIndex, puzzle[emptyIndex - 1]);
            puzzle.RemoveAt(emptyIndex - 1);
            puzzle.Insert(emptyIndex - 1, 0);
            return puzzle;
        }

    }
}

