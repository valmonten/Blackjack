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

        public IDeck Deck { get; private set;}

        public ITable Table { get; private set; }

        public List<IGambler> Gamblers { get; private set; }

        public IDealer Dealer { get; private set; }

        public IInputProvider InputProvider { get; private set; }
        public IOutputProvider OutputProvider { get; private set; }
        public ITableRenderer TableRenderer { get; private set; }


        public void DirectGamblerChoice(IInputProvider inputProvider, IChoiceProvider choiceProvider, IPlayer gambler, IPlayer dealer)
        {
            throw new NotImplementedException();
        }

        public void PerformSingleTurn()
        {
            // If gambler, prompt for action
            // Once action is received, parse action and execute accordingly
            // If necessary, prompt for action again
            // If player stays or busts, end turn and update game state
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
            // Instantiate player and ask for name, instantiate dealer and table and deck and I/O
            GameState = GameState.WaitingToStart;
            Deck = new Deck();
            Gambler player1 = new Gambler();
            Gamblers = new List<IGambler> { player1 };
            Dealer = new Dealer();
            InputProvider = new ConsoleInputProvider();
            OutputProvider = new ConsoleOutputProvider();
            TableRenderer = new ConsoleTableRenderer();

            Console.WriteLine("Please enter your name, gambler");
            string gamblerName = InputProvider.Read();
            player1.Name = gamblerName;



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
