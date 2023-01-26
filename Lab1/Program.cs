using Lab1;
using System;
public class main
    {
    static public void Main()
    {
        Engine obj= new Engine();
        ConsoleKey input;
        List<int> puzzle = new List<int>();

        Console.WriteLine("Enter Size(x-axis) of puzzle");
        int size = Convert.ToInt32(Console.ReadLine());

        obj.start_puzzle(size);
        
        while ((input = Console.ReadKey().Key) != ConsoleKey.Escape)
        {
            obj.move(input);
        }
    }
}
