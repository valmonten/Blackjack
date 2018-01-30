using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// Receive input from the user via the console
    /// </summary>
    public class ConsoleInputProvider : Blackjack.Interfaces.IInputProvider
    {
        public void Read()
        {
            Console.ReadLine();
        }
    }
}
