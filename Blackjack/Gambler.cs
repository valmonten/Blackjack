﻿using System;
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

        //TODO:
        //public List<ICard> Hand { get; set; }

        public Gambler(string name)
        {
            Name = name;
            Hand = new Hand();
        }


        /// <summary>
        /// For unit-testing.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="name"></param>
        public Gambler(Hand hand, string name) : this(name)
        {
            Hand = hand;
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

        public void ClearHand()
        {
            Hand = new Hand();
        }
    }
}
