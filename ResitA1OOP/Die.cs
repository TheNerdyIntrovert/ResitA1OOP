using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGames
{
    /// <summary>
    /// Represents a single die that can be rolled.
    /// </summary>
    internal class Die
    {
        // Fields
        private static readonly Random _generator = new Random();
        private int _numberOfSides;
        private int _currentValue;

        /// <summary>
        /// Gets or sets the number of sides on the die.
        /// Must be between 2 and 32 inclusive.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is less than 2 or greater than 32.</exception>
        public int NumberOfSides
        {
            get { return _numberOfSides; }
            set
            {
                if (value < 2 || value > 32)
                {
                    throw new ArgumentOutOfRangeException("A die must have between 2 - 32 sides.");
                }
                _numberOfSides = value;
            }
        }

        /// <summary>
        /// Gets the current value of the die.
        /// </summary>
        public int CurrentValue
        {
            get { return _currentValue; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Die"/> class with the specified number of sides.
        /// </summary>
        /// <param name="NumberOfSides">The number of sides for the die. Default is 6.</param>
        public Die(int NumberOfSides = 6)
        {
            this.NumberOfSides = NumberOfSides;
            NewRoll();
        }

        /// <summary>
        /// Rolls the die and sets <see cref="CurrentValue"/> to a new random value between 1 and <see cref="NumberOfSides"/>.
        /// </summary>
        public void NewRoll()
        {
            _currentValue = _generator.Next(1, _numberOfSides + 1);
        }
    }
}
