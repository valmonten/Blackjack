using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Gambler : IGambler, IPlayer
    {
        public double Money { get; set; }
        public string Name { get; set; }
        public IHand Hand { get; set; }
        public IHand SplitHand { get; set; }
        public bool isHandSplit { get; private set; }

        //TODO:
        //public List<ICard> Hand { get; set; }

        public Gambler(string name) : this(new Hand(), name)
        {
        }


        /// <summary>
        /// For unit-testing.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="name"></param>
        public Gambler(Hand hand, string name)
        {
            Hand = hand;
            Name = name;
            isHandSplit = false;
            SplitHand = new Hand();
            
        }

        /// <summary>
        /// player can choose to Gamble, hence using the Money. Yet to implement.
        /// </summary>
        public void Gamble()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Player calls GetCard to get a card from the Dealer.
        /// The Card is then added to Player's Hand.
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns>ICard</returns>
        public ICard GetCard(IDealer dealer)
        {
            ICard card = dealer.Deal();
            Hand.AllCards.Add(card);
            return card;
        }
        public ICard GetSplitcard(IDealer dealer)
        {
            ICard card = dealer.Deal();
            SplitHand.AllCards.Add(card);
            return card;
        }

        public void ClearHand()
        {
            Hand = new Hand();
            SplitHand = new Hand();
            isHandSplit = false;
        }
        public void SplitTheHand()
        {
            if(isHandSplit==true)
            {
                throw new InvalidOperationException("You already split! You can only split once!");
            }
            if(Hand.Count!=2)
            {
                throw new InvalidOperationException("Can only split two cards");
            }
            if(Hand.AllCards[0].Face!=Hand.AllCards[1].Face)
            {
                throw new InvalidOperationException("Cannot split the hand if the cards are not the same face!");
            }
            var splitcard = Hand.AllCards[1];
            Hand.AllCards.RemoveAt(1);
            SplitHand.AllCards.Add(splitcard);
            isHandSplit = true;

               
        }
    }
}
