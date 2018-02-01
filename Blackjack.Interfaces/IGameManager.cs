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
        Queue<IPlayer> PlayersInOrder { get;  }
        IInputProvider InputProvider { get; }
        IOutputProvider OutputProvider { get; }
        ITableRenderer TableRenderer { get;  }

        void StartGame();

        void GamblerPerformsSingleTurn(IGambler gambler);
        void DealerPerformsSingleTurn();
        void SwitchTurns(IPlayer player);
        void PlayAgain();
        void ResetScreen();

        
    }
}
