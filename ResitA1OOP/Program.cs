using DiceGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Testing testing_class = new Testing();
            testing_class.RunDieTest();

            ThreeOrMoreManager game1 = new ThreeOrMoreManager();
            game1.StartGame();

            SevensOutManager game2 = new SevensOutManager();
            game2.StartGame();
        }
    }
}