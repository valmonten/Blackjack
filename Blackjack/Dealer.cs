﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Dealer : IDealer
    {
        public IDeck Deck { get; set; }
        public string Name { get; set; }
        public List<ICard> Hand { get; set; }

        public ICard Deal()
        {
            return Deck.DrawCard();
        }

        public ICard GetCard(IDealer dealer)
        {
            ICard card = dealer.Deal();
            this.Hand.Add(card);
            return card;
        }
    }
}
