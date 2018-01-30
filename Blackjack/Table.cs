using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Table : Blackjack.Interfaces.ITable
    {
        public IPlayer Dealer { get; set; }
        public List<IPlayer> Players { get; set; }
    }
}
