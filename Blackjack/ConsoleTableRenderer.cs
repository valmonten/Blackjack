using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using System.Configuration;

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
            Console.WriteLine("Dealer: ");
            ShowHand(table.Dealer);
            //loop through a player's hand and print their cards
            foreach(var player in table.Players)
            {
                Console.WriteLine(player.Name + ":");
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
            Console.WriteLine("Dealer: ");
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
            Console.WriteLine(player.Name + ": ");
            RevealHand(player.Hand);
            //foreach(var card in player.Hand.AllCards)
            //{
            //    Console.Write(string.Format("({0} of {1}) ", card.Face, card.Suit));
            //}
            //Console.WriteLine();
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
                Console.Write(ConfigurationManager.AppSettings["CardTop"]);
                Console.WriteLine(ConfigurationManager.AppSettings["CardTop"]);
                Console.Write(ConfigurationManager.AppSettings["CardLeft"]);
                Console.Write(card.Face);
                for (int i = 0; i < 5 - card.Face.ToString().ToList().Count; i++)
                    Console.Write(" ");
                Console.Write(ConfigurationManager.AppSettings["CardRight"]);
                Console.WriteLine(ConfigurationManager.AppSettings["HiddenCard"]);
                if (card.Suit == CardSuit.Club)
                    Console.Write(ConfigurationManager.AppSettings["ClubTop"]);
                if (card.Suit == CardSuit.Diamond)
                    Console.Write(ConfigurationManager.AppSettings["DiamondTop"]);
                if (card.Suit == CardSuit.Heart)
                    Console.Write(ConfigurationManager.AppSettings["HeartTop"]);
                if (card.Suit == CardSuit.Spade)
                    Console.Write(ConfigurationManager.AppSettings["SpadeTop"]);
                Console.WriteLine(ConfigurationManager.AppSettings["HiddenCard"]);
                if (card.Suit == CardSuit.Club)
                    Console.Write(ConfigurationManager.AppSettings["ClubBottom"]);
                if (card.Suit == CardSuit.Diamond)
                    Console.Write(ConfigurationManager.AppSettings["DiamondBottom"]);
                if (card.Suit == CardSuit.Heart)
                    Console.Write(ConfigurationManager.AppSettings["HeartBottom"]);
                if (card.Suit == CardSuit.Spade)
                    Console.Write(ConfigurationManager.AppSettings["SpadeBottom"]);
                Console.WriteLine(ConfigurationManager.AppSettings["HiddenCard"]);
                Console.Write(ConfigurationManager.AppSettings["CardBase"]);
                Console.WriteLine(ConfigurationManager.AppSettings["CardBase"]);
                Console.Write(ConfigurationManager.AppSettings["CardBottom"]);
                Console.WriteLine(ConfigurationManager.AppSettings["CardBottom"]);
            }
            if (dealer.Hand.Count == 1)
            {
                //Show placeholder for hidden dealer card
                Console.Write(ConfigurationManager.AppSettings["CardTop"]);
                Console.Write("(HIDDEN CARD)");
            }
            Console.WriteLine();
        }
        public void RevealHand(IHand hand)
        {
            for (int i = 0; i < hand.Count; i++)
                Console.Write(ConfigurationManager.AppSettings["CardTop"]);
            Console.WriteLine();
            foreach (ICard card in hand.AllCards)
            {

                Console.Write(ConfigurationManager.AppSettings["CardLeft"]);
                Console.Write(card.Face);
                for (int i = 0; i < 5 - card.Face.ToString().ToList().Count; i++)
                    Console.Write(" ");
                Console.Write(ConfigurationManager.AppSettings["CardRight"]);
            }
            Console.WriteLine();
            foreach (ICard card in hand.AllCards)
            {
                if (card.Suit == CardSuit.Club)
                    Console.Write(ConfigurationManager.AppSettings["ClubTop"]);
                if(card.Suit == CardSuit.Diamond)
                    Console.Write(ConfigurationManager.AppSettings["DiamondTop"]);
                if (card.Suit == CardSuit.Heart)
                    Console.Write(ConfigurationManager.AppSettings["HeartTop"]);
                if (card.Suit == CardSuit.Spade)
                    Console.Write(ConfigurationManager.AppSettings["SpadeTop"]);
            }
            Console.WriteLine();
            foreach (ICard card in hand.AllCards)
            {
                if (card.Suit == CardSuit.Club)
                    Console.Write(ConfigurationManager.AppSettings["ClubBottom"]);
                if (card.Suit == CardSuit.Diamond)
                    Console.Write(ConfigurationManager.AppSettings["DiamondBottom"]);
                if (card.Suit == CardSuit.Heart)
                    Console.Write(ConfigurationManager.AppSettings["HeartBottom"]);
                if (card.Suit == CardSuit.Spade)
                    Console.Write(ConfigurationManager.AppSettings["SpadeBottom"]);
            }
            Console.WriteLine();
            for (int i = 0; i < hand.Count; i++)
                Console.Write(ConfigurationManager.AppSettings["CardBase"]);
            Console.WriteLine();
            for (int i = 0; i < hand.Count; i++)
                Console.Write(ConfigurationManager.AppSettings["CardBottom"]);
            Console.WriteLine();
        }
    }
}
