using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    /// <summary>
    /// Table for generic BlackJack game
    /// </summary>
    public class Table : ITable
    {
        public IDealer Dealer { get; protected set; }
        public IEnumerable<IGambler> Players { get; protected set; }
        public bool AreAllHandsComplete { get; protected set; }

        /// <summary>
        /// Constructor for Table
        /// </summary>
        /// <param name="dealer">an IPlayer of type IDealer</param>
        /// <param name="players">a list </param>
        public Table(IDealer dealer, IEnumerable<IGambler> players)
        {
            if(dealer == null)
            {
                throw new ArgumentNullException("Dealer cannot be null");
            }
            if(players == null)
            {
                throw new ArgumentNullException("Players cannot be null");
            }
            Dealer = dealer;
            Players = players;
            AreAllHandsComplete = false;
        }

        public void CompleteAllHands()
        {
            AreAllHandsComplete = true;
        }
    }
}
