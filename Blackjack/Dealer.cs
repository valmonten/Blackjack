using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Dealer : IDealer
    {
        public IDeck Deck { get; set; }
        public string Name { get; set; }
        public List<ICard> Hand { get; set; }

        public ICard Deal()
        {
            throw new NotImplementedException();
        }

        public ICard GetCard(IDealer dealer)
        {
            throw new NotImplementedException();
        }
    }
}
