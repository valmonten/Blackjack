using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Gambler : IGambler
    {
        public double Money { get; set; }
        public string Name { get; set; }
        public List<ICard> Hand { get; set; }

        public void Gamble()
        {
            throw new NotImplementedException();
        }

        //public ICard HitMe(IDealer dealer)
        //{
        //    return dealer.Deal(this);
        //}

        public ICard GetCard(IDealer dealer)
        {
            ICard card = dealer.Deal();
            this.Hand.Add(card);
            return card;
        }

        //public void Stay()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
