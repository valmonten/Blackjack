using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    /// <summary>
    /// Render the table to the console
    /// </summary>
    public class ConsoleTableRenderer : ITableRenderer
    {
        /// <summary>
        /// Render the table to the user(s)
        /// </summary>
        /// <param name="table">Representation of the cards in play</param>
        public void Render(ITable table)
        {
            //Check if the table is invalid
            if(table == null)
                throw new ArgumentNullException("Cannot render null");
            //Show all hands
            if (table.AreAllHandsComplete)
                ShowAllHands(table);
            //Show only the players' hand(s)
            else
                ShowPlayersHands(table);
            
        }

        /// <summary>
        /// Reveal all hands. Only to be called after all players have stayed or busted.
        /// </summary>
        /// <param name="table"></param>
        public void ShowAllHands(ITable table)
        {
            if (table == null)
                throw new ArgumentNullException("Table cannot be null");
            //Clear previous table view
            Console.Clear();
            //Show dealer cards
            Console.Write("Dealer: ");
            ShowHand(table.Dealer);
            //loop through a player's hand and print their cards
            foreach(var player in table.Players)
            {
                Console.Write($"{0}: ", player.Name);
                ShowHand(player);
            }
        }

        /// <summary>
        /// function to show only the players' hand(s) and limited dealer hand info
        /// </summary>
        /// <param name="table">ITable representation of the BlackJack table</param>
        public void ShowPlayersHands(ITable table)
        {
            //Check for a valid table
            if (table == null)
                throw new ArgumentNullException("Table cannot be null");
            //Render hidden dealer info
            Console.Write("Dealer: ");
            HideHand(table.Dealer);
            //Render cards for each player
            foreach(var player in table.Players)
            {
                ShowHand(player);
            }
        }

        /// <summary>
        /// reveal a single player's hands
        /// </summary>
        /// <param name="player">The IPlayer in the game</param>
        public void ShowHand(IPlayer player)
        {
            //Check for invalid player
            if (player == null)
                throw new ArgumentNullException("Cannot show cards of null");
            //display each card
            foreach(var card in player.Hand.AllCards)
            {
                Console.Write($"({0} of {1}) ", card.Face, card.Suit);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// hide the last card dealt to the dealer
        /// </summary>
        /// <param name="dealer">The IDealer for the game</param>
        public void HideHand(IDealer dealer)
        {
            //Check for invalid dealer
            if (dealer == null)
                throw new ArgumentNullException("Cannot hide a card for null");
            //Check function was legitimately called
            if(dealer.Hand.Count > 2)
                throw new Exception("Dealer has too many cards to hide");
            //Show visible dealer card
            if (dealer.Hand.Count == 2)
            {
                var card = dealer.Hand.AllCards.FirstOrDefault();
                Console.Write("( " + card.Face + " of " + card.Suit + ") ");
                Console.WriteLine();
            }
            //Show placeholder for hidden dealer card
            Console.Write("(HIDDEN CARD)");
            Console.WriteLine();
        }
    }
}
