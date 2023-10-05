using System;
namespace Lab1
{
	public class Menu
	{
		public void menu()
		{
			Console.WriteLine("Hello, Welcome to N-Puzzle \n" +
							  "////////////////////////// \n" +
							  "1 - Start Game             \n" +
							  "2 - Exit Game              \n" +
							  "////////////////////////// \n");
			int choice = Convert.ToInt32(Console.ReadLine());
			switch (choice)
			{
				case 1:
                    Engine engine;

                    Console.Clear(); 
                    Console.WriteLine("Hello, Welcome to N-Puzzle \n" +
									  "////////////////////////// \n" +           
									  "1 - Board 3x3              \n" +
                                      "2 - Board 4x4              \n" +
                                      "3 - Board 5x5              \n" +
                                      "4 - Board 6x6              \n" +
                                      "5 - Board 7x7              \n" +
                                      "////////////////////////// \n");
                    choice = Convert.ToInt32(Console.ReadLine());
					switch (choice)
					{
                        case 1:
                            engine = new Engine(9);
                            break;
                        case 2:

                            engine = new Engine(16);
                            break;
                        case 3:  
                            engine = new Engine(25);
                            break;
                        case 4:
                            engine = new Engine(36);
                            break;
                        case 5:
                            engine = new Engine(49);
                            break;
                    }
					break;
				case 2:
					break;
			}
		}
	}
}

