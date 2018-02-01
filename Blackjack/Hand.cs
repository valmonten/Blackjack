using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Hand : IHand
    {
        /// <summary>
        /// Provide an IEnumerable of Cards in a Hand.
        /// </summary>
        public IList<ICard> AllCards { get; set; }

        /// <summary>
        /// Return the Count of Cards in a Hand.
        /// </summary>
        public int Count
        {
            get
            {
                if (AllCards == null)
                    throw new NullReferenceException();
                return AllCards.Count();
            }
        }

        public Hand()
        {
            AllCards = new List<ICard>();
        }
       

        /// <summary>
        /// Sum the value of the hand (all the cards' value). 
        /// </summary>
        /// <returns>int sum</returns>
        public int SumCardsValue()
        {
            foreach (var card in AllCards.Where(c => c.Face == CardFace.Ace))
            {
                card.Value = 1;
            }

            int sum = AllCards.Sum(c => c.Value);
            if (AllCards.Any(c => c.Face == CardFace.Ace) && sum <= 21)
            {
                AllCards.FirstOrDefault(c => c.Face == CardFace.Ace).Value = 11;
                sum = AllCards.Sum(c => c.Value);
            }
            return sum;
        }
    }
}
