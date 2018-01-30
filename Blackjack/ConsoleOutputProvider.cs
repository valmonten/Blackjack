using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    /// <summary>
    /// Print output to the console.
    /// </summary>
    public class ConsoleOutputProvider : IOutputProvider
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
