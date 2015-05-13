using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsResults.Sports
{
    /// <summary>
    /// Abstract class for Sports Events.
    /// </summary>
    public abstract class SportsEvent
    {
        private string opponent1;
        private string opponent2;
        private string date;

        /// <summary>
        /// Default constructor for SportsEvent class.
        /// </summary>
        public SportsEvent()
        {
        }

        /// <summary>
        /// Parameterized constructor for SportsEvent class.
        /// </summary>
        /// <param name="firstOpponent">The name of the first opponent of the sports event.</param>
        /// <param name="secondOpponent">The name of the second opponent of the sports event.</param>
        /// <param name="date">Date of the sports event.</param>
        public SportsEvent(string firstOpponent, string secondOpponent, string date)
        {
            opponent1 = firstOpponent;
            opponent2 = secondOpponent;
            this.date = date;
        }

        /// <summary>
        /// Get and Set properties for the first opponent of the sports event.
        /// </summary>
        public string Opponent1
        {
            get { return opponent1; }
            set { opponent1 = value; }
        }

        /// <summary>
        /// Get and Set properties for the second opponent of the sports event.
        /// </summary>
        public string Opponent2
        {
            get { return opponent2; }
            set { opponent2 = value; }
        }

        /// <summary>
        /// Get and Set properties for the Date of the sports event.
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Abstract method for calculating the winner of the sports event.
        /// </summary>
        /// <returns>The name of the winner or a tie.</returns>
        public abstract string Winner();
    }
}
