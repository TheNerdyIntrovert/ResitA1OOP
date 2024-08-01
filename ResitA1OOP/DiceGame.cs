using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGames
{
    /// <summary>
    /// Represents an abstract base class for a dice game.
    /// </summary>
    internal abstract class DiceGame
    {
        /// <summary>
        /// List of dice used in the game.
        /// </summary>
        protected List<Die> _dice;

        /// <summary>
        /// Current score of the game.
        /// </summary>
        protected int _score;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceGame"/> class with the specified number of dice.
        /// </summary>
        /// <param name="NumberOfDiceNeeded">The number of dice needed for the game.</param>
        protected DiceGame(int NumberOfDiceNeeded)
        {
            _dice = new List<Die>();
            for (int i = 0; i < NumberOfDiceNeeded; i++)
            {
                _dice.Add(new Die(10)); // Can be adjusted if needs be - this is just how I interpret the examples
            }
            _score = 0;
        }

        /// <summary>
        /// Rolls all the dice in the game.
        /// </summary>
        protected void RollAllDice()
        {
            foreach (var die in _dice)
            {
                die.NewRoll();
            }
        }

        /// <summary>
        /// Displays the current values of all dice in the game.
        /// </summary>
        protected void DisplayDice()
        {
            for (int i = 0; i < _dice.Count; i++)
            {
                Console.WriteLine($"Die {i + 1}: {_dice[i].CurrentValue}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the current score of the game.
        /// </summary>
        protected void DisplayScore()
        {
            Console.WriteLine($"Current score: {_score}");
        }

        /// <summary>
        /// Plays a turn of the game.
        /// </summary>
        /// <returns>The score for the turn.</returns>
        public abstract int PlayTurn();
    }
}
