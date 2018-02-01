using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public enum GameState
    {
        WaitingToStart,
        Started,
        WaitingForUserInput,
        PerformingMove,
        CheckingForGameOver,
        Draw,
        Winner
    }
    public interface IGameManager
    {
        GameState GameState { get; }

        ITable Table { get; }
        List<IGambler> Gamblers { get;  }
        IDealer Dealer { get;  }
        IInputProvider InputProvider { get; }
        IOutputProvider OutputProvider { get; }
        ITableRenderer TableRenderer { get;  }

        void StartGame();

        void PerformSingleTurn();
        void SwitchTurns();
        void PlayAgain();
        void ResetScreen();
        void DirectGamblerChoice(IInputProvider inputProvider, IChoiceProvider choiceProvider, IPlayer gambler, IPlayer dealer);

        
    }
}
