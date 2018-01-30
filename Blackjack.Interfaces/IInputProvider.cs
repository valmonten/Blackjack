using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    //Interface for receiving input from the IPlayer
    /// <summary>
    /// Source of input for the player(s)
    /// </summary>
    public interface IInputProvider
    {
        string Read();
    }
}
