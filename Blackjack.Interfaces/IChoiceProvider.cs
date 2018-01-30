using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public enum Choice
    {
        Hit,
        Stay
    }
    interface IChoiceProvider
    {
        void DirectHitChoice(IPlayer gambler, IPlayer dealer, Choice choice);
    }
}
