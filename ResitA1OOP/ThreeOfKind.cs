using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGames
{
    /// <summary>
    /// Represents an individual game of Three or More.
    /// </summary>
    internal class ThreeOrMoreIndividual : DiceGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeOrMoreIndividual"/> class with 5 dice.
        /// </summary>
        public ThreeOrMoreIndividual() : base(5) { }

        /// <summary>
        /// Plays a turn of the Three or More game.
        /// </summary>
        /// <returns>The score for the turn.</returns>
        public override int PlayTurn()
        {
            int rollsAvailable = 1;
            RollAllDice();

            while (true)
            {
                DisplayDice();

                int maximumRun = CalculateMaximumRun();
                if (maximumRun < 2)
                {
                    _score = 0;
                    Console.WriteLine("There are no (2/3/4/5) of a kind runs here");
                    break;
                }
                if (maximumRun == 5)
                {
                    _score = 12;
                    Console.WriteLine("You have a 5 of a kind run!");
                    break;
                }

                for (int i = 2; i < 5; i++)
                {
                    if (maximumRun == i)
                    {
                        _score = 3 * (int)Math.Pow(2.0, i - 3);
                        Console.WriteLine($"You have a {i} of a kind run.");
                    }
                }
                if (rollsAvailable < 1) { break; }

                Console.WriteLine("Would you like to reroll your dice? (Y/...)");
                string response1 = Console.ReadLine();
                if (response1 == "Y")
                {
                    Console.WriteLine("Please enter die you would like to reroll (1-5) separated by spaces");
                    string response2 = Console.ReadLine();

                    for (int i = 0; i < 5; i++)
                    {
                        if (response2.Split(' ').Count(x => x == (i + 1).ToString()) > 0)
                        {
                            _dice[i].NewRoll();
                        }
                    }
                    rollsAvailable -= 1;
                }
                else { rollsAvailable = 0; break; }
            }
            DisplayScore();
            return _score;
        }

        /// <summary>
        /// Calculates the maximum run of the same value in the dice rolls.
        /// </summary>
        /// <returns>The maximum run of the same value.</returns>
        private int CalculateMaximumRun()
        {
            List<int> rollValues = new List<int>();
            foreach (Die die in _dice)
            {
                rollValues.Add(die.CurrentValue);
            }

            int maximumRun = 1;
            for (int i = 1; i <= _dice[0].NumberOfSides; i++)
            {
                int dieValueCount = rollValues.Count(x => x == i);
                if (dieValueCount > maximumRun)
                {
                    maximumRun = dieValueCount;
                }
            }
            return maximumRun;
        }
    }

    /// <summary>
    /// Manages the Three or More game.
    /// </summary>
    internal class ThreeOrMoreManager
    {
        /// <summary>
        /// Starts a new game of Three or More.
        /// </summary>
        public void StartGame()
        {
            List<int> gameScores = new List<int> { 0, 0 };
            int playCounter = 0;
            while (true)
            {
                int playerIndex = (playCounter % 2) + 1;
                Console.WriteLine($"It's player {playerIndex}'s turn.");
                ThreeOrMoreIndividual new_game = new ThreeOrMoreIndividual();
                gameScores[playerIndex - 1] += new_game.PlayTurn();

                for (int player = 1; player < 3; player++)
                {
                    Console.WriteLine($"Player {player}'s score: {gameScores[player - 1]}");
                }

                if (gameScores.Count(x => x < 20) == 1)
                {
                    Console.WriteLine("End of game!");
                    break;
                }
                playCounter++;
                Console.WriteLine();
            }
        }
    }
}
