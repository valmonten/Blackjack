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
        List<ICard> Hand { get; set; }

        // Asks dealer for another card that gets added to Hand
        ICard GetCard(IDealer dealer);

        // Makes the hand empty
        void ClearHand();

    }
}
