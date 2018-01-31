using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    /// <summary>
    /// Returns input from the user via the console
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Accept input from the player
        /// </summary>
        /// <returns>play</returns>
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
