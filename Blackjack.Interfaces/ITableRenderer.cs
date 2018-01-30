using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    //Interface to render the blackjack table
    /// <summary>
    /// Uses the state of the table to render current table state to the player(s)
    /// </summary>
    public interface ITableRenderer
    {
        ITable Table { get; set; }
    }
}
