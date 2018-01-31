using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    //interface for current table
    //needs a list of players to access player's hands
    /// <summary>
    /// Interface for table, necessary to display game to player(s)
    /// </summary>
    public interface ITable
    {
        IDealer Dealer { get; }
        IEnumerable<IGambler> Players { get; }
        bool AreAllHandsComplete { get; }
        void CompleteAllHands();
    }
}
