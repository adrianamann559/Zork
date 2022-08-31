using System;

namespace Zork
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine().Trim().ToUpper();
            Commands command = ToCommand(inputString);
            if (command == Commands.QUIT)
            {
                Console.WriteLine("Thanks you for playing.");
            }
            else if (command == Commands.LOOK)
            {
                 Console.WriteLine("This is an open field west of a white house, with a boarded up front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
            }
            else if (command == Commands.NORTH)
            {
                Console.WriteLine("You moved north.");
            }
            else if (command == Commands.SOUTH)
            {
                Console.WriteLine("You moved south.");
            }
            else if (command == Commands.EAST)
            {
                Console.WriteLine("You moved east.");
            }
            else if (command == Commands.WEST)
            {
                Console.WriteLine("You moved west.");
            }
            else
            {
              Console.WriteLine($"Unrecognized command: {inputString}");
            }
        }

        static Commands ToCommand(string commandString)
        {
            if (Enum.TryParse<Commands>(commandString, true, out Commands command))
            {
                return command;
            }
            else
            {
                return Commands.UNKNOWN;
            }

            switch (commandString)
            {
                case "QUIT":
                    command = Commands.QUIT;
                    break;

                case "LOOK":
                    command = Commands.LOOK;
                    break;

                case "NORTH":
                    command = Commands.NORTH;
                    break;

                case "SOUTH":
                    command = Commands.SOUTH;
                    break;

                case "EAST":
                    command = Commands.EAST;
                    break;

                case "WEST":
                    command = Commands.WEST;
                    break;

                default:
                    command = Commands.UNKNOWN;
                    break;
            }

           
        }
      
         
       
    }
}
