using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    // Interface for players
    public interface IPlayer
    {
        // The player's name
        string Name { get; set; }

        // The cards the player has
        ICard[] Hand { get; set; }

        // Hit me asks dealer for another card that gets added to Hand
        ICard HitMe();

        // Player takes no more cards
        void Stay();

    }
}
