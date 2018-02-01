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

        public ITable Table { get; private set; }

        public List<IGambler> Gamblers { get; private set; }

        public IDealer Dealer { get; private set; }

        public IInputProvider InputProvider { get; private set; }
        public IOutputProvider OutputProvider { get; private set; }
        public ITableRenderer TableRenderer { get; private set; }

        /// <summary>
        /// Instantiates GameManager Class, inheirits overloaded constructor for dependency injection
        /// </summary>
        public GameManager() : this(new Dealer(new Deck(), "Dealer"), new ConsoleInputProvider(),
            new ConsoleOutputProvider(),
            new ConsoleTableRenderer())
        {

        }

        /// <summary>
        /// Overloaded constructor for dependency injection
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="dealer"></param>
        /// <param name="inputProvider"></param>
        /// <param name="outputProvider"></param>
        /// <param name="tableRenderer"></param>
        public GameManager(IDealer dealer, IInputProvider inputProvider, 
            IOutputProvider outputProvider, ITableRenderer tableRenderer)
        {
            Dealer = dealer;
            InputProvider = inputProvider;
            OutputProvider = outputProvider;
            TableRenderer = tableRenderer;
        }


        /// <summary>
        /// Prompts player to make a choice of hitting or staying, continues until win condition 
        /// determined, or player stays
        /// </summary>
        /// <param name="gambler"></param>
        public void GamblerPerformsSingleTurn(IGambler gambler)
        {
            if (gambler == null)
            {
                throw new ArgumentNullException("Gambler cannot be null");
            }

            // Prompt for action
            OutputProvider.WriteLine("Please Select H to hit or S to stay");
            GameState = GameState.WaitingForUserInput;
            var choice = InputProvider.Read();
            
            // Once action is received, parse action and execute accordingly
            GameState = GameState.PerformingMove;

            // If choice is to hit, have dealer deal card to player, and determine if win condition met
            if (choice == "H")
            {
                gambler.GetCard(Dealer);
                ResetScreen();
                // If Win condition met, call play again. If not, perform another turn
                GameState = GameState.CheckingForGameOver;
                if (DetermineWinner())
                {
                    PlayAgain();
                    return;
                }
                else
                {
                    GamblerPerformsSingleTurn(gambler);
                }
            }

            // If player stays, switch turns
            SwitchTurns(Dealer);
        }

        public void DealerPerformsSingleTurn()
        {
            // Calculate dealer's current hand

            // If value of hand is below 17, dealer hits

            // If over 17, the dealer stays

            // Set GameState to CheckingForGameOver and return
            GameState = GameState.CheckingForGameOver;
            //return;
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
                OutputProvider.WriteLine("Would you like to play another game of Blackjack? (y/n)");
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
                    OutputProvider.WriteLine("Okay, goodbye! (Press any key to exit)");
                    InputProvider.Read();
                }
                // If user inputs another response, ask the user for a correct input.
                else
                {
                    isUserInputIncorrect = true;
                    OutputProvider.WriteLine("Sorry, could you repeat that?");
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
            OutputProvider.WriteLine();
            TableRenderer.Render(Table);
            OutputProvider.WriteLine();
        }

        /// <summary>
        /// Starts the new game.
        /// </summary>
        public void StartGame()
        {
            // Welcome user(s) to the game.
            string welcomeSign =
                @"
                .------..------..------..------..------..------..------..------..------.
                |B.--. ||L.--. ||A.--. ||C.--. ||K.--. ||J.--. ||A.--. ||C.--. ||K.--. |
                | :(): || :/\: || (\/) || :/\: || :/\: || :(): || (\/) || :/\: || :/\: |
                | ()() || (__) || :\/: || :\/: || :\/: || ()() || :\/: || :\/: || :\/: |
                | '--'B|| '--'L|| '--'A|| '--'C|| '--'K|| '--'J|| '--'A|| '--'C|| '--'K|
                `------'`------'`------'`------'`------'`------'`------'`------'`------'
            ";
            OutputProvider.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - (welcomeSign.Length / 16)) / 2, Console.CursorTop);
            OutputProvider.WriteLine(welcomeSign);
            OutputProvider.WriteLine();

            // Ask user for number of players
            // Instantiate player(s) and ask for name(s), then instanitate the table
            GameState = GameState.WaitingToStart;
            OutputProvider.WriteLine("Please enter your name, gambler.");
            string gamblerName = InputProvider.Read();
            Gambler gambler = new Gambler(gamblerName);
            Gamblers = new List<IGambler> { gambler };
            Table = new Table(Dealer, Gamblers);


            // Deal cards to player and dealer (2 each)
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    Dealer.GetCard(Dealer);
                }
                else
                {
                    gambler.GetCard(Dealer);
                }
            }

            // Render table and hands
            TableRenderer.Render(Table);

            // Initiate 
            GameState = GameState.Started;
            if (DetermineWinner() == true)
            {
                PlayAgain();
            }
            else
            {
                // Turns start and finish within this call stack
                GamblerPerformsSingleTurn(gambler);
                
                // Once all turns are done, determine winner
                DetermineWinner();

                // Ask player(s) if they want to play again
                PlayAgain();
            }
            
        }

        public void SwitchTurns(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null");
            }

            if (player == Dealer)
                DealerPerformsSingleTurn();
            else
                GamblerPerformsSingleTurn(player as Gambler);
        }

        /// <summary>
        /// Helper function that gets the amount of points per hand, and determines whether there's a winner
        /// </summary>
        public bool DetermineWinner()
        {
            return false;
        }
    }
}
