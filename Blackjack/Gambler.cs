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

        /// <summary>
        /// The constructor for gamemanager to use
        /// </summary>
        /// <param name="name">Name of the gambler</param>
        public Gambler(string name) : this(new Hand(), name)
        {
        }


        /// <summary>
        /// Constructor for testing
        /// </summary>
        /// <param name="hand">The hand instantiated by the constructor chain</param>
        /// <param name="name">The name of the player</param>
        public Gambler(Hand hand, string name)
        {
            Hand = hand;
            Name = name;
            isHandSplit = false;
            SplitHand = new Hand();
            
        }

        /// <summary>
        /// Constructor used for testing using ishandsplit bool
        /// </summary>
        /// <param name="tf">bool of hand being split already</param>
        /// <param name="hand">Hand of the player</param>
        /// <param name="name">Name of the player</param>
        public Gambler(bool tf, IHand hand, string name)
        {
            isHandSplit = tf;
            Hand = hand;
            Name = name;
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
        /// <summary>
        /// Method to add a card the the splithands
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public ICard GetSplitcard(IDealer dealer)
        {
            ICard card = dealer.Deal();
            SplitHand.AllCards.Add(card);
            return card;
        }

        /// <summary>
        /// Clears the hand, the splithand and resets the ishandsplit to false
        /// </summary>
        public void ClearHand()
        {
            Hand = new Hand();
            SplitHand = new Hand();
            isHandSplit = false;
        }

        /// <summary>
        /// Splits the hand, keeping the first card in the hand property and adding the second card to the splithand property
        /// </summary>
        public void SplitMe()
        {
            if (isHandSplit == true)
            {
                throw new InvalidOperationException("You already split! You can only split once!");
            }
            if (Hand.Count != 2)
            {
                throw new InvalidOperationException("Can only split two cards");
            }
            if (Hand.AllCards[0].Face!=Hand.AllCards[1].Face)
            {
                throw new InvalidOperationException("Cannot split the hand if the cards are not the same face!");
            }
            //Copies second card in hand
            var splitcard = Hand.AllCards[1];

            //Removes second card in hand
            Hand.AllCards.RemoveAt(1);

            //Adds coppied card to splithand
            SplitHand.AllCards.Add(splitcard);

            //Sets boolean because the hand was split
            isHandSplit = true;

               
        }
    }
}
