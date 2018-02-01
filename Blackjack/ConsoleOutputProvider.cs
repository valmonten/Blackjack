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
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLine(string op)
        {
            Console.WriteLine(op);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(string op)
        {
            Console.Write(op);
        }
    }
}
