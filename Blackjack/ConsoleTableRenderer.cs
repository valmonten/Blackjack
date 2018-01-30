using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class ConsoleTableRenderer : ITableRenderer
    {
        public void Render()
        { }
        public void Render(ITable table)
        {
            throw new NotImplementedException();
        }
    }
}
