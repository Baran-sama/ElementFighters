using System;

namespace ElementFighters
{
    class MainMenu
    {
        public void Display()
        {
            ShowIntro();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true); 
            ShowMainMenu();
        }

        private void ShowIntro()
        {
            Console.Clear();
            Console.WriteLine("  ______________________________________________________________________");
            Console.WriteLine(" |                                                                      |");
            Console.WriteLine(" |                          ELEMENT FIGHTERS                            |");
            Console.WriteLine(" |                                                                      |");
            Console.WriteLine(" | Fire, Water, Air, Earth and more element users in a fight            |");
            Console.WriteLine(" | to become the best elemental fighter. Choose your character          |");
            Console.WriteLine(" | and fight your way to the top!                                       |");
            Console.WriteLine(" |______________________________________________________________________|");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Element Fighter!");
            Console.WriteLine("Choose your elemental character and fight against other characters!");
            Console.WriteLine("Each character is fighting to become the best element user in the world!");
            Console.WriteLine();
        }

        private void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Element Fighters!");
                DrawElementArt();
                Console.WriteLine();
                Console.WriteLine("P - Start the Game");
                Console.WriteLine("G - Character Guide");
                Console.WriteLine("Q - Exit the Game");

                var input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case 'P':
                    case 'p':
                        GameSetup();
                        break;
                    case 'G':
                    case 'g':
                        DisplayCharacterGuide();
                        break;
                    case 'Q':
                    case 'q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please select a valid option.");
                        continue;
                }
            }
        }

        private void DrawElementArt()
        {
            Console.WriteLine("Wind:");
            Console.WriteLine(" __     __");
            Console.WriteLine(" \\ \\   / /");
            Console.WriteLine("  \\ \\_/ / ");
            Console.WriteLine("   \\   /  ");
            Console.WriteLine("    \\_/   ");
            Console.WriteLine();

            Console.WriteLine("Fire:");
            Console.WriteLine("  ( ( (");
            Console.WriteLine("   ) ) )");
            Console.WriteLine("  ( ( (");
            Console.WriteLine("   ) ) )");
            Console.WriteLine("  ( ( (");
            Console.WriteLine();

            Console.WriteLine("Water:");
            Console.WriteLine("  ~~~~  ");
            Console.WriteLine(" ~    ~ ");
            Console.WriteLine("  ~  ~  ");
            Console.WriteLine("   ~~   ");
            Console.WriteLine();

            Console.WriteLine("Earth:");
            Console.WriteLine("  ____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |____|");
        }

        private void GameSetup()
        {
            Console.Clear();
            bool isPlayer1Human = GetPlayerType(1);
            bool isPlayer2Human = GetPlayerType(2);

            Character player1Character = SelectCharacter(1);
            Character player2Character = SelectCharacter(2);

            Game game = new Game(isPlayer1Human, isPlayer2Human, player1Character, player2Character);
            game.Start();
        }

        private void DisplayCharacterGuide()
        {
            CharacterGuide guide = new CharacterGuide();
            guide.Display();
        }

        private bool GetPlayerType(int playerNumber)
        {
            while (true)
            {
                Console.WriteLine($"Is player {playerNumber} human (h) or computer (c)?");
                var input = Console.ReadKey(true).KeyChar;
                if (input == 'h' || input == 'H')
                {
                    return true;
                }
                else if (input == 'c' || input == 'C')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select 'h' for human or 'c' for computer.");
                }
            }
        }

        private Character SelectCharacter(int playerNumber)
        {
            Console.Clear();
            Console.WriteLine($"Player {playerNumber}, select your character:");
            Console.WriteLine("1 - Luke");
            Console.WriteLine("2 - James");
            Console.WriteLine("3 - Jon");
            Console.WriteLine("4 - David");
            Console.WriteLine("5 - Melkha");
            Console.WriteLine("6 - Paul");

            while (true)
            {
                var input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case '1': return new Luke();
                    case '2': return new James();
                    case '3': return new Jon();
                    case '4': return new David();
                    case '5': return new Melkha();
                    case '6': return new Paul();
                    default:
                        Console.WriteLine("Invalid input. Please select a valid character number.");
                        continue;
                }
            }
        }
    }
}
