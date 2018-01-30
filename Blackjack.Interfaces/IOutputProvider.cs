using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    //interface for rendering output to the player
    /// <summary>
    /// Takes an Output to render to the player(s)
    /// </summary>
    public interface IOutputProvider
    {
        void Print(string op);
    }
}
