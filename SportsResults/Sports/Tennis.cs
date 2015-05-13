using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsResults.Sports
{
    /// <summary>
    /// The Tennis class is derived from the SportsEvent base class.  It
    /// represents a Tennis sport object.
    /// </summary>
    class Tennis : SportsEvent
    {
        private int[] scores;

        /// <summary>
        /// Default constructor for Tennis class.
        /// </summary>
        public Tennis()
        {
        }

        /// <summary>
        /// Parameterized constructor for Tennis class.
        /// </summary>
        /// <param name="date">Date of Hockey event.</param>
        /// <param name="player1">Name of the first tennis player.</param>
        /// <param name="player2">Name of the second tennis player.</param>
        /// <param name="scores">Scores for the tennis match.</param>
        public Tennis(string date, string player1, string player2, int[] scores)
            : base(player1, player2, date)
        {
            this.scores = scores;
        }

        /// <summary>
        /// Get and Set properties for the final scores of the sports event.
        /// </summary>
        public int[] Scores
        {
            get { return scores; }
            set { scores = value; }
        }
        
        /// <summary>
        /// Calculates the winner of the tennis match.
        /// </summary>
        /// <returns>Returns the name of the tennis match winner or a tie.</returns>
        public override string Winner()
        {
            int player1Total = 0;
            int player2Total = 0;

            for (int count = 0; count < Scores.Length; count += 2 )
            {
                player1Total += Scores[count];
            }

            for (int count = 1; count < Scores.Length; count += 2)
            {
                player2Total += Scores[count];
            }

            if ( player1Total < player2Total)
            {
                return Opponent2;
            }
            else if (player1Total == player2Total)
            {
                return "Tie";
            }
            else
            {
                return Opponent1;
            }
        }
    }
}
