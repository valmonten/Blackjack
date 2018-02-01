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
        //Deck dealer will deal cards from
        public IDeck Deck { get; set; }
        //Name of dealer
        public string Name { get; set; }
        //The cards the dealer has in his hand
        //public List<ICard> Hand { get; set; }

        public IHand Hand { get; set; }

        /// <summary>
        /// Constructor for deck when a deck is not specified.
        /// </summary>
        /// <param name="name">Name of the dealer</param>
        public Dealer (string name) : this(new Deck(), name)
        {
        }
        /// <summary>
        /// Constructor for deck and name to be passed in
        /// </summary>
        /// <param name="deck">The deck the game is being played with and that the dealer will deal from.</param>
        /// <param name="name">Name of the dealer</param>
        public Dealer(IDeck deck, string name)
        {
            Deck = deck;
            Name = name;
        }

        /// <summary>
        /// Deal calls drawcard on the deck and returns it to the function that called it, EG GetCard
        /// </summary>
        /// <returns>Returns the card to be added to hand</returns>
        public ICard Deal()
        {
            return Deck.DrawCard();
        }

        /// <summary>
        /// GetCard is used to deal the first hand and when player asks to be hit
        /// </summary>
        /// <param name="dealer">dealer is passed in to be able to call the dealer's deal method</param>
        /// <returns>Returns the ICard in case it can be used for rendering. 
        /// Otherwise the card is added to this players hand</returns>
        public ICard GetCard(IDealer dealer)
        {
            ICard card = dealer.Deal();
            this.Hand.AllCards.ToList().Add(card);
            return card;
        }

        //Clears the hand of the player
        public void ClearHand()
        {
            Hand = new Hand();
        }
    }
}
