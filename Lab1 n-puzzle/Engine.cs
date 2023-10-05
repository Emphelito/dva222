using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Engine
    {
        private bool runEngine = true;
        private int times = 0;
        public Engine(int size)
        {
            Bord bord = new Bord(size);
            statusCondition statcon= new statusCondition(bord.getSize());
            Moving move = new Moving(bord.getSize(), bord);
            Draw print = new Draw(bord.getSize(), move.getBord());
            do
            {
                print.printPuzzle(bord, move.getBord());
                statcon.statusCheck(bord, move.getBord());

                if (statcon.getStatus()) runEngine = false;

                else
                {
                    ConsoleKey loggedKey = Console.ReadKey().Key;
                    times++;

                    if (loggedKey == ConsoleKey.UpArrow)
                    {
                        move.moveUp(bord);
                    }
                    if (loggedKey == ConsoleKey.DownArrow)
                    {
                        move.moveDown(bord);
                    }
                    if (loggedKey == ConsoleKey.RightArrow)
                    {
                        move.moveRight(bord);
                    }
                    if (loggedKey == ConsoleKey.LeftArrow)
                    {
                        move.moveLeft(bord);
                    }
                    if (loggedKey == ConsoleKey.Escape || statcon.getStatus()) runEngine = false;
                }
            } while (runEngine);
            Console.WriteLine(times);
        }
    }
}
