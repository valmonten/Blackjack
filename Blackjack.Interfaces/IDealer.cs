using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IDealer : IPlayer
    {
        // ICard Deal(IPlayer player);
        ICard Deal();
        IDeck Deck { get; set; }
        
    }
}
