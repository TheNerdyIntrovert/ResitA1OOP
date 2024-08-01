using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGames
{
    public class Testing
    {
        public void RunDieTest()
        {
            try
            {
                // Test with invalid number of sides
                Console.WriteLine("Testing with invalid number of sides (1):");
                Die invalidDie = new Die(1); // This will throw an exception
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message); // Output: A die must have between 2 and 32 sides.
            }

            // Test with valid number of sides
            Console.WriteLine("\nTesting with a valid die (6 sides):");
            Die validDie = new Die(6);

            // Roll the die multiple times
            for (int i = 0; i < 5; i++)
            {
                validDie.NewRoll();
                Console.WriteLine($"Roll {i + 1}: {validDie.CurrentValue}");
                if (validDie.CurrentValue < 1 ||  validDie.CurrentValue > validDie.NumberOfSides)
                {
                    Console.Write(" - this roll is outside of the die range;");
                }
            }

            // Test with another valid die
            Console.WriteLine("\nTesting with another valid die (10 sides):");
            Die anotherValidDie = new Die(10);

            // Roll the die multiple times
            for (int i = 0; i < 5; i++)
            {
                anotherValidDie.NewRoll();
                Console.WriteLine($"Roll {i + 1}: {anotherValidDie.CurrentValue}");
                if (validDie.CurrentValue < 1 || validDie.CurrentValue > validDie.NumberOfSides)
                {
                    Console.Write(" - this roll is outside of the die range;");
                }
            }
        }
    }
}
