using System;

namespace ElementFighters
{
    class CharacterGuide
    {
        public void Display()
        {
            Console.Clear();
            Character[] characters = new Character[]
            {
                new Luke(),
                new James(),
                new Jon(),
                new David(),
                new Melkha(),
                new Paul()
            };

            foreach (var character in characters)
            {
                Console.WriteLine($"Name: {character.Name}");
                Console.WriteLine($"HP: {character.MaxHP}"); // Display max HP instead of current HP
                Console.WriteLine("Moves:");
                character.DisplayMoves();
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
