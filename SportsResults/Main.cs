using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using SportsResults.Sports;

namespace SportsResults
{
    /// <summary>
    /// The Main class takes the file and attempts to read the file.  If file exists
    /// it will read it and create the appropriate sports event.
    /// </summary>
    class Main
    {
        private const char STRINGSEPERATOR = ',';
        private const string TENNIS = "tennis";
        private const string HOCKEY = "hockey";
        private const int SCOREOFFSET = 4;
        private const int SPORTNAME = 0;
        private const int DATE = 1;
        private const int NAME1 = 2;
        private const int NAME2 = 3;

        private SportsCollection sports = new SportsCollection();
        private string dataFile;
        private StreamReader streamReader = null;

        /// <summary>
        /// Default constructor for the Main class.
        /// </summary>
        public Main()
        {
        }

        /// <summary>
        /// Parameterized constructor for the Main class.
        /// </summary>
        /// <param name="fileName">Name of the sports file to read.</param>
        public Main(string fileName)
        {
            dataFile = fileName;
        }

        /// <summary>
        /// Reads the text file and calls private helper methods to create the appropriate
        /// sports event.
        /// </summary>
        public void ReadFile()
        {
            if (File.Exists(dataFile))
            {
                try
                {
                    streamReader = new StreamReader(dataFile);

                    while (streamReader.Peek() > 0)
                    {
                        AddItem(ReadString(streamReader.ReadLine()));
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("\n{0}\n", ex.Message);
                }

                finally
                {
                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("\nFile not found.\n");
            }
        }

        // Reads the string and splits the string.
        private string[] ReadString(string readLine)
        {
            return readLine.Split(STRINGSEPERATOR);
        }

        // Takes in the split string and adds the sports event to the collection.
        private void AddItem(string[] splitString)
        {
            switch (splitString[SPORTNAME].ToLower())
            {
                case TENNIS:
                    {
                        sports.Add(new Tennis(splitString[DATE], splitString[NAME1], splitString[NAME2], GetScores(splitString)));
                        break;
                    }
                case HOCKEY:
                    {
                        sports.Add(new Hockey(splitString[DATE], splitString[NAME1], splitString[NAME2], GetScores(splitString)));
                        break;
                    }
            }
        }

        // Gets the scores from the split string array and return the scores as an int 
        // array.
        private int[] GetScores(string[] stringArray)
        {
            int[] scores = new int[stringArray.Length - SCOREOFFSET];
            int result;

            for (int count = SCOREOFFSET; count < stringArray.Length; count++)
            {
                int.TryParse(stringArray[count], out result);
                scores[count - SCOREOFFSET] = result;
            }
            return scores;
        }

        /// <summary>
        /// Displays the sports results on the console.
        /// </summary>
        public void DisplaySports()
        {
            foreach (SportsEvent sport in sports)
            {
                if ( sport is Tennis )
                {
                    Tennis sportEvent = sport as Tennis;
                    if (sportEvent != null)
                    {
                        string score1 = "";
                        string score2 = "";

                        for (int count = 0; count < sportEvent.Scores.Length; count += 2 )
                        {
                            score1 += sportEvent.Scores[count];
                            score1 += count + 2 < sportEvent.Scores.Length ? ", " : "";
                        }

                        for (int count = 1; count < sportEvent.Scores.Length; count += 2)
                        {
                            score2 += sportEvent.Scores[count];
                            score2 += count + 2 < sportEvent.Scores.Length ? ", " : "";
                        }

                        Console.WriteLine("******************************Tennis Result******************************");
                        Console.WriteLine("{0, -6} {1, 15} {2, 8} {3, 14} {4, 8} {5, 12}", "Date", "Player 1", "Scores", "Player 2", "Scores", "Winner");
                        Console.WriteLine("{0, -13} {1, -10} {2, -12} {3, -10} {4, -12} {5}", sportEvent.Date, sportEvent.Opponent1, score1, sportEvent.Opponent2,
                            score2, sportEvent.Winner());
                    }
                }

                if (sport is Hockey)
                {
                    Hockey sportEvent = sport as Hockey;
                    if (sportEvent != null)
                    {
                        Console.WriteLine("******************************Hockey Result******************************");
                        Console.WriteLine("{0, -10} {1, 10} {2, 8} {3, 10} {4, 8} {5, 10}", "Date", "Team 1", "Score", "Team 2", "Score", "Winner");
                        Console.WriteLine("{0, -14} {1, 6} {2, 7:D} {3, 10} {4, 8:D} {5, 11}", sportEvent.Date, sportEvent.Opponent1, sportEvent.Scores[0], sportEvent.Opponent2,
                            sportEvent.Scores[1], sportEvent.Winner());
                    }
                }
                Console.WriteLine("\n\n");
                
            }
        }
    }
}
