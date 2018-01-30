using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class ConsoleTableRenderer : Blackjack.Interfaces.ITableRenderer
    {
        public ITable Table { get; set; }
        public ConsoleTableRenderer(ITable table)
        {
            Table = table;
        }
    }
}
