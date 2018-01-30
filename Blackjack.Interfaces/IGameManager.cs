using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    enum GameState
    {
        WaitingToStart,
        Started,
        WaitingForUserInput,
        PerformingMove,
        CheckingForGameOver,
        Draw,
        Winner
    }
    interface IGameManager
    {
        GameState GameState { get; }
        IDeck Deck { get;  }
        ITable Table { get; }
        IPlayer Gambler { get;  }
        IPlayer Dealer { get;  }

        void DirectGamblerChoice(IInputProvider inputProvider, IChoiceProvider choiceProvider, IPlayer gambler, IPlayer dealer);
        
    }
}
