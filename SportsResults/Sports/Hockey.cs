using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsResults.Sports
{
    /// <summary>
    /// The Hockey class is derived from the SportsEvent base class.  It represents
    /// a Hockey sport object.
    /// </summary>
    class Hockey : SportsEvent
    {
        private int[] scores;

        /// <summary>
        /// Default Constructor for Hockey class.
        /// </summary>
        public Hockey()
        {
        }

        /// <summary>
        /// Parameterized Constructor for Hockey class
        /// </summary>
        /// <param name="date">Date of the hockey event</param>
        /// <param name="team1">Name of team 1.</param>
        /// <param name="team2">Name of team 2.</param>
        /// <param name="scores">Final scores for hockey game.</param>
        public Hockey(string date, string team1, string team2, int[] scores)
            : base(team1, team2, date)
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
        /// Calculates the winner of the Hockey game.
        /// </summary>
        /// <returns>Returns the name of the winning team or a tie.</returns>
        public override string Winner()
        {
            if (Scores[0] < Scores[1] )
            {
                return Opponent2;
            }
            else if (Scores[0] == Scores[1])
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
