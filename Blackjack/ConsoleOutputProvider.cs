using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// Print output to the console.
    /// </summary>
    public class ConsoleOutputProvider : Blackjack.Interfaces.IOutputProvider
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
