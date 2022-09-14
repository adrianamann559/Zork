using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Zork
{
    
    class Program
    {
        public static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());
               
                switch(command)
                {
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded up front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.QUIT:
                        Console.WriteLine("Thanks for playing");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                          Console.WriteLine("The way is shut!");
                        }
                       break;

                    default:
                        Console.WriteLine("Unrecognized Command. Try Again, Buddy.");
                        break;
                }
            }

        }

        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction.");

            bool isValidMove = true; 
            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Row++;
                    break;

                case Commands.WEST when Location.Column > 0:
                    Location.Row++;
                    break;

                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }
        private static Commands ToCommand(string commandString) =>
            Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static readonly Room[,] Rooms =
        {
            {new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View")},
            {new Room("Forest"), new Room ("West of House"), new Room ("Behind House")},
            {new Room("Dense Woods"), new Room("North of House"), new Room ("Clearing")}
        };

        private static void IntializeRoomDescriptions()
        {
            Rooms[0, 0].Description = ""; //Rocky Trail
            Rooms[0, 1].Description = ""; //South of House
            Rooms[0, 2].Description = ""; //Canyon View

            Rooms[1, 0].Description = ""; //Forest
            Rooms[1, 1].Description = ""; //West of House
            Rooms[1, 2].Description = ""; //Behind House

            Rooms[2, 0].Description = ""; //Dense Woods
            Rooms[2, 1].Description = ""; //North of House
            Rooms[2, 2].Description = ""; //Clearing
        }

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST,
        };

        private static (int Row, int Column) Location = (1, 1);
       

    }
}
