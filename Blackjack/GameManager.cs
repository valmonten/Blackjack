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
        public Queue<IPlayer> PlayersInOrder { get; private set; }

        public IInputProvider InputProvider { get; private set; }
        public IOutputProvider OutputProvider { get; private set; }
        public ITableRenderer TableRenderer { get; private set; }

        /// <summary>
        /// Instantiates GameManager Class, inheirits overloaded constructor for dependency injection
        /// </summary>
        public GameManager() : this(new Dealer(new Deck(), "Dealer"), new ConsoleInputProvider(),
            new ConsoleOutputProvider(),
            new ConsoleTableRenderer(), new Queue<IPlayer>())
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
            IOutputProvider outputProvider, ITableRenderer tableRenderer, Queue<IPlayer> playersInOrder)
        {
            Dealer = dealer;
            InputProvider = inputProvider;
            OutputProvider = outputProvider;
            TableRenderer = tableRenderer;
            PlayersInOrder = playersInOrder;
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

            // Ask user for number of gamblers
            // Instantiate player(s), ask for name(s), and add to list of gamblers.
            GameState = GameState.WaitingToStart;
            OutputProvider.WriteLine("Please enter your name, gambler.");
            string gamblerName = InputProvider.Read();
            Gambler gambler = new Gambler(gamblerName);
            Gamblers = new List<IGambler> { gambler };

            // Add players to queue, gambler first
            PlayersInOrder.Enqueue(gambler);
            PlayersInOrder.Enqueue(Dealer);

            // Instantiate the table
            Table = new Table(Dealer, Gamblers);

            // Build a deck for the dealer
            Dealer.Deck.Build();

            // Shuffle the deck
            Dealer.Deck.Shuffle(10);

            // Deal 2 cards each to gambler and dealer
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
            ResetScreen();

            // Initiate 
            GameState = GameState.Started;
            if (DetermineWinner(gambler, Dealer) == true)
            {
                PlayAgain();
                return;
            }
            else
            {
                // Turns start and finish within this call stack
                GamblerPerformsSingleTurn(gambler);

            }         
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
            OutputProvider.WriteLine("Please select [H] to hit or [S] to stay");
            GameState = GameState.WaitingForUserInput;
            var choice = InputProvider.Read();

            // Once action is received, parse action and execute accordingly
            GameState = GameState.PerformingMove;

            // If choice is to hit, have dealer deal card to player, and determine if win condition met
            if (choice == "H" || choice == "h")
            {
                gambler.GetCard(Dealer);
                ResetScreen();
                // If Win condition met, call play again. If not, perform another turn
                GameState = GameState.CheckingForGameOver;
                if (gambler.Hand.SumCardsValue() == 21)
                {
                    Table.CompleteAllHands();
                    ResetScreen();
                    OutputProvider.WriteLine("YOU HAVE 21! Let's see what the dealer does");
                    PlayersInOrder.Dequeue();
                    SwitchTurns(Dealer);
                    return;
                }
                else if (gambler.Hand.SumCardsValue() > 21)
                {
                    Table.CompleteAllHands();
                    ResetScreen();
                    OutputProvider.WriteLine("BUSTED! YOU LOSE!");
                    GameState = GameState.Winner;
                    PlayAgain();
                    return;
                }
                else
                {
                    GamblerPerformsSingleTurn(gambler);
                }
            }
            // If player selects stay, switch turns
            else if (choice == "S" || choice == "s")
            {
                PlayersInOrder.Dequeue();
                SwitchTurns(Dealer);
            }
            // If any other button is pushed, display error message and try again.
            else
            {
                OutputProvider.WriteLine("Invalid button selected!");
                OutputProvider.WriteLine("Press any key to try again");
                InputProvider.Read();
                GamblerPerformsSingleTurn(gambler);
            }
        }

        public void DealerPerformsSingleTurn(IDealer dealer)
        {
            if (dealer == null)
            {
                throw new ArgumentNullException("Dealer cannot be null!");
            }

            

            Table.CompleteAllHands();

            // Calculate dealer's current hand
            int dealerHand = Dealer.Hand.SumCardsValue();

            // If over 17, the dealer stays
            if (dealerHand > 17)
            {
                PlayersInOrder.Dequeue();
                // Set GameState to CheckingForGameOver and return
                GameState = GameState.CheckingForGameOver;
                if (DetermineWinner(Gamblers[0], Dealer))
                {
                    GameState = GameState.Winner;
                    PlayAgain();
                    return;
                }

                throw new ArgumentException("Winner could not be determined.");
            }
            // If value of hand is below 17, dealer hits
            else
            {
                GameState = GameState.PerformingMove;
                dealer.GetCard(Dealer);
                ResetScreen();
                DealerPerformsSingleTurn(Dealer);
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

        public void SwitchTurns(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null");
            }

            if (player == Dealer)
                DealerPerformsSingleTurn(player as Dealer);
            else
                GamblerPerformsSingleTurn(player as Gambler);
        }

        /// <summary>
        /// Helper function that gets the amount of points per hand, and determines whether there's a winner
        /// </summary>
        public bool DetermineWinner(IGambler gambler, IDealer dealer)
        {
            // Calculate hand of gambler and dealer
            int dealerHandVal = Dealer.Hand.SumCardsValue();
            int gamblerHandVal = gambler.Hand.SumCardsValue();

            // If queue is not empty, and nobody is over 21 then return false

            // If queue > 0, and dealer has blackjack, dealer automatically wins
            if (PlayersInOrder.Count > 0 && dealerHandVal == 21)
            {
                OutputProvider.WriteLine("DEALER HAS BLACKJACK YOU LOSE");
                GameState = GameState.Winner;
                return true;
            }

            // If Queue > 0, dealer has < 21, and player has 21, player wins
            else if (PlayersInOrder.Count > 0 && dealerHandVal < 21 && gamblerHandVal == 21)
            {
                Table.CompleteAllHands();
                OutputProvider.WriteLine("YOU WIN!");
                GameState = GameState.Winner;
                return true;
            }

            else if (PlayersInOrder.Count > 0 && dealerHandVal < 21 && gamblerHandVal < 21)
            {
                return false;
            }

            // If both hands are the same and the queue is empty, game is a push
            else if (dealerHandVal == gamblerHandVal && PlayersInOrder.Count < 1)
            {

                OutputProvider.WriteLine("PUSH!");
            }

            // Otherwise, higher value wins
            else if (dealerHandVal > gamblerHandVal && PlayersInOrder.Count < 1)
            {
                OutputProvider.WriteLine("YOU LOSE!");
            }

            else if (gamblerHandVal > dealerHandVal && PlayersInOrder.Count < 1)
            {
                OutputProvider.WriteLine("YOU WIN!");
            }

            else if (PlayersInOrder.Count < 1 && dealerHandVal > 21)
            {
                OutputProvider.WriteLine("DEALER BUSTED! YOU WIN!");
            }

            GameState = GameState.Winner;
            return true;
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
                    break;
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
    }
}
