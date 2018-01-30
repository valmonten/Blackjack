using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class ConsoleTableRenderer : ITableRenderer
    {
        public void Render(ITable table)
        {
            Console.Write("Dealer's Cards: ");
            //show dealer's visible cards
            
            //Go to a new line to display player's cards
            Console.WriteLine();
            
            //show all player's cards
            foreach(var player in table.Players)
            {
                Console.Write(player.ToString());
            }
        }
        //helper function to show a player's hand.
        public void ShowHand(IPlayer player)
        {
            //loop through a player's hand 
            Console.Write("player's hand");
        }
    }
}
