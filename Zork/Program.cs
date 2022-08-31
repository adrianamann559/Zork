using System;

namespace Zork
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("> ");
                string inputString = Console.ReadLine().Trim().ToUpper();
                Commands command = ToCommand(inputString);

                string outputString;
                switch(command)
                {
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded up front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.QUIT:
                        outputString = "Thanks for playing!";
                      isRunning = false;
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = $"You moved {command}.";
                        break;

                    default:
                        outputString = "Unrecognized Command. Try Again, Buddy.";
                        break;
                }

                Console.WriteLine(outputString);
            }

        }

        static Commands ToCommand(string commandString)
        {
            if (Enum.TryParse<Commands>(commandString, true, out Commands result))
            {
                return result;
            }
            else
            {
                return Commands.UNKNOWN;
            }
            
        }   
    }
}
