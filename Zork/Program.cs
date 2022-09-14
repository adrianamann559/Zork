using System;
using System.Diagnostics.CodeAnalysis;

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
                Console.Write($"{_rooms[_currentRoom]}\n > ");
                string inputString = Console.ReadLine().Trim();
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
                        if (Move(command))
                        {
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                       
                        }
                       break;

                    default:
                        outputString = "Unrecognized Command. Try Again, Buddy.";
                        break;
                }

                Console.WriteLine(outputString);
            }

        }

        private static Commands ToCommand(string commandString)
        {

            return Enum.TryParse<Commands>(commandString, ignoreCase: true, out Commands command) ? command : Commands.UNKNOWN;
        }

        private static bool Move(Commands command)
        {
            bool didMove = false; 

            switch (command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                didMove = false;
                    break;

                case Commands.EAST when _currentRoom < _rooms.Length - 1:
                        _currentRoom++;
                        didMove = true;
                    break;

                case Commands.WEST when _currentRoom > 0:
                        _currentRoom--;
                        didMove = true; 
                    break;

                default:
                    didMove = false;
                    break;
            }

            return didMove;
        }
        private static readonly string[] _rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
        private static int _currentRoom = 1;

    }
}
