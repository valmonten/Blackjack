using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// Returns input from the user via the console
    /// </summary>
    public class ConsoleInputProvider : Blackjack.Interfaces.IInputProvider
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
