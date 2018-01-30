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
    interface IGameManager
    {
        Choice GamblerChoice { get; set; }
        void DirectGamblerChoice(IInputProvider inputProvider, IChoiceProvider choiceProvider, IPlayer gambler, IPlayer dealer);
    }
}
