using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDeck
    {
        /// <summary>
        /// Builds new deck of cards.
        /// </summary>
        void Build();

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Clear the deck completely.
        /// </summary>
        void Reset();
    }
}
