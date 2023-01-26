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
			//int choice = Convert.ToInt32(Console.ReadLine());
			switch (1)
			{
				case 1:
					Bord bord;
					Draw draw = new Draw();
                    Console.WriteLine("Hello, Welcome to N-Puzzle \n" +
									  "////////////////////////// \n" +
									  "1 - Board 2x2              \n" +
									  "2 - Board 3x3              \n" +
                                      "3 - Board 4x4              \n" +
                                      "4 - Board 5x5              \n" +
                                      "5 - Board 6x6              \n" +
                                      "6 - Board 7x7              \n" +
                                      "////////////////////////// \n");
                    //choice = Convert.ToInt32(Console.ReadLine());
					switch (1)
					{
						case 1:
							bord = new Bord(4);
							draw.printPuzzle(bord);
							break;
                        case 2:
                            bord = new Bord(9);
                            break;
                        case 3:
                            bord = new Bord(16);
                            break;
                        case 4:
                            bord = new Bord(25);
                            break;
                        case 5:
                            bord = new Bord(36);
                            break;
                        case 6:
                            bord = new Bord(49);
                            break;
                    }
					break;
				case 2:
					break;
			}
		}
	}
}

