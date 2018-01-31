using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    // The Dealer interface
    public interface IDealer : IPlayer
    {
        // Returns a card that can be added to a hand
        ICard Deal();
        // The deck a dealer will be dealing from
        IDeck Deck { get; set; }
        
    }
}
