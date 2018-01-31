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
        /// <summary>
        /// Render the table to the user(s)
        /// </summary>
        /// <param name="table">Representation of the cards in play</param>
        public void Render(ITable table)
        {
            if(table == null)
                throw new ArgumentNullException("Cannot render null");
            if (table.AreAllHandsComplete)
                ShowAllHands(table);
            ShowPlayersHands(table);
            
        }

        /// <summary>
        /// Reveal all hands. Only to be called after all players have stayed or busted.
        /// </summary>
        /// <param name="table"></param>
        public void ShowAllHands(ITable table)
        {
            Console.Write("Dealer's Hand: ");
            ShowHand(table.Dealer);
            //loop through a player's hand and print their cards
            Console.Write("player's hand");
        }

        /// <summary>
        /// function to show only the players' hand(s) and limited dealer hand info
        /// </summary>
        /// <param name="table">ITable representation of the BlackJack table</param>
        public void ShowPlayersHands(ITable table)
        {

        }

        /// <summary>
        /// reveal a single player's hands
        /// </summary>
        /// <param name="player">The IPlayer in the game</param>
        public void ShowHand(IPlayer player)
        {

        }

        /// <summary>
        /// hide the last card dealt to the dealer
        /// </summary>
        /// <param name="dealer">The IDealer for the game</param>
        public void HideHand(IDealer dealer)
        {

        }
    }
}
