using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class GameManager : IGameManager
    {
        public GameState GameState { get; private set; }

        public IDeck Deck => throw new NotImplementedException();

        public ITable Table => throw new NotImplementedException();

        public List<IPlayer> Gambler => throw new NotImplementedException();

        public IPlayer Dealer => throw new NotImplementedException();

        public void DirectGamblerChoice(IInputProvider inputProvider, IChoiceProvider choiceProvider, IPlayer gambler, IPlayer dealer)
        {
            throw new NotImplementedException();
        }

        public void PerformSingleTurn()
        {
            throw new NotImplementedException();
        }

        public void PlayAgain()
        {
            throw new NotImplementedException();
        }

        public void ResetScreen()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            // Instantiate player and ask for name, instantiate dealer and table and deck
            // Deal cards to player and dealer (2 each)
            // Render table
            // Initiate turns
            // Perform action(s)
            // Switch turns
            // Check/update game state
            // Once all turns are down, determine winner
            // Prompt to play again, if yes repeat cycle, if no reset screen
        }

        public void SwitchTurns()
        {
            throw new NotImplementedException();
        }
    }
}
