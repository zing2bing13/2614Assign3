using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsResults
{
    /// <summary>
    /// Program class is the driver that starts the Main program.  It gets the name
    /// of the file from the command line arguments and verifies that a argument has
    /// been passed from the command line.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Main mainProgram = new Main(args[0]);
                mainProgram.ReadFile();
                mainProgram.DisplaySports();
            }
            else
            {
                System.Console.WriteLine("Please enter a sports results file: eg. results.csv");
            }
        }
    }
}
