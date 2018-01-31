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

        /// <summary>
        /// Helper function to ask user if they want to play the game again.
        /// </summary>
        public void PlayAgain()
        {
            var isUserInputIncorrect = true;
            while (isUserInputIncorrect)
            {
                // Ask user if they want to play again.
                OutputProvider.Print("Would you like to play another game of Blackjack? (y/n)");
                var playerResponse = InputProvider.Read();

                // If user replies "y", then clear the console and reload a new game.
                if (playerResponse == "y")
                {
                    isUserInputIncorrect = false;
                    OutputProvider.Clear();
                    Program.NewGame();
                }
                // If user replies "n", exit the console after a key press.
                else if (playerResponse == "n")
                {
                    isUserInputIncorrect = false;
                    OutputProvider.Print("Okay, goodbye! (Press any key to exit)");
                    InputProvider.Read();
                }
                // If user inputs another response, ask the user for a correct input.
                else
                {
                    isUserInputIncorrect = true;
                    OutputProvider.Print("Sorry, could you repeat that?");
                    continue;
                }
            }
        }

        /// <summary>
        /// Helper function to clear the screen, and redraw the table.
        /// </summary>
        public void ResetScreen()
        {
            OutputProvider.Clear();
            OutputProvider.Print();
            // Draw the table.
            OutputProvider.Print();
        }

        /// <summary>
        /// Starts the new game.
        /// </summary>
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
