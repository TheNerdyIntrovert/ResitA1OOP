using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGames
{
    /// <summary>
    /// Represents an individual game of Sevens Out.
    /// </summary>
    internal class SevensOutIndividual : DiceGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SevensOutIndividual"/> class with 2 dice.
        /// </summary>
        public SevensOutIndividual() : base(2) { }

        /// <summary>
        /// Plays a turn of the Sevens Out game.
        /// </summary>
        /// <returns>The score for the turn.</returns>
        /// <exception cref="Exception">Thrown when the total of the dice is 7, indicating game over.</exception>
        public override int PlayTurn()
        {
            RollAllDice();
            DisplayDice();

            int total = 0;
            bool isWorthDouble = true;
            int currentDieValue = _dice[0].CurrentValue;

            foreach (Die die in _dice)
            {
                total += die.CurrentValue;
                if (currentDieValue != die.CurrentValue)
                {
                    isWorthDouble = false;
                }
            }

            if (total == 7)
            {
                throw new Exception("You rolled a 7. Game Over.");
            }

            if (isWorthDouble)
            {
                _score = total * 2;
            }
            else
            {
                _score = total;
            }

            DisplayScore();
            return _score;
        }
    }

    /// <summary>
    /// Manages the Sevens Out game.
    /// </summary>
    internal class SevensOutManager
    {
        /// <summary>
        /// Starts a new game of Sevens Out.
        /// </summary>
        public void StartGame()
        {
            int gameScore = 0;
            while (true)
            {
                try
                {
                    SevensOutIndividual game = new SevensOutIndividual();

                    int turnScore = game.PlayTurn();
                    gameScore += turnScore;
                    Console.WriteLine("Please press enter to roll the dice again.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Your final score is {gameScore}. Thanks for playing.");
                    break;
                }
            }
        }
    }
}
